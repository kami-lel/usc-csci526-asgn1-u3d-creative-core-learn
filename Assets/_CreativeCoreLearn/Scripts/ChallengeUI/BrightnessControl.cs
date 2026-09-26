using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Screen brightness via a full screen black overlay image: slider value maps
/// to overlay alpha, and the choice persists across sessions.
/// </summary>
public class BrightnessControl : MonoBehaviour {
    private const string PREFS_KEY = "Brightness";
    private const float MIN_BRIGHTNESS = 0.2f;  // floor, screen never fully black

    [SerializeField] private Slider slider;
    [SerializeField] private Image overlay;  // black, stretched, raycast off

    private void Awake() {
        // overlay may be authored inactive, must be live to dim
        overlay.gameObject.SetActive(true);
        slider.minValue = MIN_BRIGHTNESS;
        slider.maxValue = 1f;
        // restore saved val w/o firing the listener
        slider.SetValueWithoutNotify(PlayerPrefs.GetFloat(PREFS_KEY, 1f));
        apply_brightness(slider.value);
    }

    private void OnEnable() {
        slider.onValueChanged.AddListener(apply_brightness);
    }

    private void OnDisable() {
        slider.onValueChanged.RemoveListener(apply_brightness);
    }

    private void apply_brightness(float val) {
        // brightness 1 → alpha 0, brightness MIN → alpha 1 - MIN
        Color color = overlay.color;
        color.a = 1f - val;
        overlay.color = color;
        PlayerPrefs.SetFloat(PREFS_KEY, val);
    }
}
