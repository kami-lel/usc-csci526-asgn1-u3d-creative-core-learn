using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Background music volume: slider value maps straight to the AudioSource
/// volume, and the choice persists across sessions.
/// </summary>
public class BgmControl : MonoBehaviour {
    private const string PREFS_KEY = "BgmVolume";
    private const float DFT_VOLUME = 0.7f;

    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource bgm;

    private void Awake() {
        slider.minValue = 0f;
        slider.maxValue = 1f;
        // restore saved val w/o firing the listener
        slider.SetValueWithoutNotify(
            PlayerPrefs.GetFloat(PREFS_KEY, DFT_VOLUME));
        apply_volume(slider.value);
    }

    private void OnEnable() {
        slider.onValueChanged.AddListener(apply_volume);
    }

    private void OnDisable() {
        slider.onValueChanged.RemoveListener(apply_volume);
    }

    private void apply_volume(float val) {
        bgm.volume = val;
        PlayerPrefs.SetFloat(PREFS_KEY, val);
    }
}
