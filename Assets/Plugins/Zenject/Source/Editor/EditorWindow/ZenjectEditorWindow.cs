using System;
using System.Collections.Generic;
using System.IO;
using ModestTree;
using UnityEditor;
using UnityEngine;
namespace Zenject {
    public abstract class ZenjectEditorWindow : EditorWindow {
        [Inject]
        [NonSerialized]
        Kernel _kernel;

        [Inject]
        [NonSerialized]
        GuiRenderableManager _guiRenderableManager;

        [NonSerialized]
        Exception _fatalError;

        [NonSerialized]
        GUIStyle _errorTextStyle;

        GUIStyle ErrorTextStyle {
            get {
                if (_errorTextStyle == null) {
                    _errorTextStyle = new GUIStyle(GUI.skin.label);
                    _errorTextStyle.fontSize = 18;
                    _errorTextStyle.normal.textColor = Color.red;
                    _errorTextStyle.wordWrap = true;
                    _errorTextStyle.alignment = TextAnchor.MiddleCenter;
                }
                return _errorTextStyle;
            }
        }

        [field: NonSerialized] protected DiContainer Container { get; private set; }

        public virtual void OnEnable() {
            if (_fatalError != null) {
                return;
            }
            Initialize();
        }

        protected virtual void Initialize() {
            Assert.IsNull(Container);
            Container = new DiContainer(new[] {
                StaticContext.Container
            });

            // Make sure we don't create any game objects since editor windows don't have a scene
            Container.AssertOnNewGameObjects = true;
            ZenjectManagersInstaller.Install(Container);
            Container.Bind<Kernel>().AsSingle();
            Container.Bind<GuiRenderableManager>().AsSingle();
            Container.BindInstance(this);
            InstallBindings();
            Container.QueueForInject(this);
            Container.ResolveRoots();
            _kernel.Initialize();
        }

        public virtual void OnDisable() {
            if (_fatalError != null) {
                return;
            }
            _kernel.Dispose();
        }

        public virtual void Update() {
            if (_fatalError != null) {
                return;
            }
            try {
                _kernel.Tick();
            }
            catch (Exception e) {
                Log.ErrorException(e);
                _fatalError = e;
            }

            // We might also consider only calling Repaint when changes occur
            Repaint();
        }

        public virtual void OnGUI() {
            if (_fatalError != null) {
                int labelWidth = 600;
                int labelHeight = 200;
                GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 3 - labelHeight / 2, labelWidth, labelHeight), "Unrecoverable error occurred!  \nSee log for details.", ErrorTextStyle);
                int buttonWidth = 100;
                int buttonHeight = 50;
                Vector2 offset = new(0, 100);
                if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2 + offset.x, Screen.height / 3 - buttonHeight / 2 + offset.y, buttonWidth, buttonHeight), "Reload")) {
                    ExecuteFullReload();
                }
            } else {
                try {
                    if (_guiRenderableManager != null) {
                        _guiRenderableManager.OnGui();
                    }
                }
                catch (Exception e) {
                    Log.ErrorException(e);
                    _fatalError = e;
                }
            }
        }

        protected virtual void ExecuteFullReload() {
            _kernel = null;
            _guiRenderableManager = null;
            Container = null;
            _fatalError = null;
            Initialize();
        }

        public abstract void InstallBindings();
    }
}
