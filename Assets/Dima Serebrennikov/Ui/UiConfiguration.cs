using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
namespace Serebrennikov {
    public class UiConfiguration : MonoBehaviour {
        [SerializeField] Button _pause;
        [SerializeField] Button _restart;
        [SerializeField] Button _resume;
        [SerializeField] GameObject _pauseWindow;
        [SerializeField] GameObject _pauseIcon;
        public GameObject PauseIcon { get => _pauseIcon; set => _pauseIcon = value; }
        public GameObject PauseWindow { get => _pauseWindow; set => _pauseWindow = value; }
        public Button Pause { get => _pause; set => _pause = value; }
        public Button Restart { get => _restart; set => _restart = value; }
        public Button Resume { get => _resume; set => _resume = value; }
    }
}
