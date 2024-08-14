using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    public float updateInterval = 1f;

    private float framesCount = 0;
    private float elapsedTime = 0;

    private void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("FPSCounter: text component not assigned!");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        framesCount++;
        elapsedTime += Time.deltaTime;

        if (elapsedTime > updateInterval)
        {
            float fps = framesCount / elapsedTime;
            fpsText.text = $"FPS: {fps:F2}";

            framesCount = 0;
            elapsedTime = 0;
        }
    }
}
