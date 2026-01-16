// SwitchShortcutsProfileOnPlay.csC:\Feeble snow\Assets\Serebrennikov\Play mode shortcuts disabling\SwitchShortcutsProfileOnPlay.csSwitchShortcutsProfileOnPlay.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UIElements;
[InitializeOnLoad]
public class SwitchShortcutsProfileOnPlay {
    const string PlayingProfileId = "Playing";
    static string _activeProfileId;
    static bool _switched;
    static SwitchShortcutsProfileOnPlay() {
        EditorApplication.playModeStateChanged += DetectPlayModeState;
    }
    static void SetActiveProfile(string profileId) {
        Debug.Log($"Activating Shortcut profile \"{profileId}\"");
        ShortcutManager.instance.activeProfileId = profileId;
    }
    static void DetectPlayModeState(PlayModeStateChange state) {
        switch (state) {
            case PlayModeStateChange.EnteredPlayMode:
                OnEnteredPlayMode();
                break;
            case PlayModeStateChange.ExitingPlayMode:
                OnExitingPlayMode();
                break;
        }
    }
    static void OnExitingPlayMode() {
        if (!_switched) {
            return;
        }
        _switched = false;
        SetActiveProfile(_activeProfileId);
    }
    static void OnEnteredPlayMode() {
        _activeProfileId = ShortcutManager.instance.activeProfileId;
        if (_activeProfileId.Equals(PlayingProfileId)) {
            return; // Same as active
        }
        List<string> allProfiles = ShortcutManager.instance.GetAvailableProfileIds().ToList();
        if (!allProfiles.Contains(PlayingProfileId)) {
            return; // Couldn't find PlayingProfileId
        }
        _switched = true;
        SetActiveProfile(PlayingProfileId);
    }
}
