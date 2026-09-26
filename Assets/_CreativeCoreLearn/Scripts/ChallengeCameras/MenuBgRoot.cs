using UnityEngine;

/// <summary>
/// Gentle idle drift for the world space menu canvas: slight vertical and
/// sideways sway around its authored local position.
/// </summary>
public class MenuBgRoot : MonoBehaviour {
    [SerializeField] private float verticalAmplitude = 0.05f;  // world units
    [SerializeField] private float verticalSpeed = 0.6f;  // cycles per second
    [SerializeField] private float sidewayAmplitude = 0.03f;  // world units
    [SerializeField] private float sidewaySpeed = 0.35f;  // cycles per second

    private Vector3 originLocalPos;
    private float verticalPhase;
    private float sidewayPhase;

    private void Awake() {
        originLocalPos = transform.localPosition;
        // rand phase, so several instances never sway in lockstep
        verticalPhase = Random.value * Mathf.PI * 2f;
        sidewayPhase = Random.value * Mathf.PI * 2f;
    }

    private void Update() {
        float t = Time.time;
        float y = Mathf.Sin(t * verticalSpeed * Mathf.PI * 2f + verticalPhase)
            * verticalAmplitude;
        float x = Mathf.Sin(t * sidewaySpeed * Mathf.PI * 2f + sidewayPhase)
            * sidewayAmplitude;
        transform.localPosition = originLocalPos + new Vector3(x, y, 0f);
    }
}
