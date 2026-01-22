// UiShootingTool.csC:\Feeble snow\Assets\Serebrennikov\Shooting tool\UiShootingTool.csUiShootingTool.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Serebrennikov {
    public class UiShootingTool : MonoBehaviour {
        [SerializeField] UiConfiguration _asset;
        Action<bool> _onSetPause = p => {};
        void Awake() {
            _asset = TheUnityObject.InstanceFromAsset(_asset);
        }
        void Start() {
            _onSetPause = p => {
                if (p) {
                    OnPause();
                } else {
                    OnResume();
                }
            };
            OnResume();
            _asset.PauseWindow.SetActive(false);
            _asset.PauseIcon.SetActive(true);
            _asset.Pause.onClick.AddListener(() => _onSetPause(true));
            _asset.Resume.onClick.AddListener(() => _onSetPause(false));
            _asset.Restart.onClick.AddListener(() => {
                TheUnityObject.Refresh();
                Loop.Refresh();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
        void OnPause() {
            _asset.PauseIcon.SetActive(false);
            _asset.PauseWindow.SetActive(true);
            Time.timeScale = 0;
        }
        void OnResume() {
            _asset.PauseIcon.SetActive(true);
            _asset.PauseWindow.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
