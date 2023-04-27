using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour
{
    private float frequency = 1.0f;
    private string fps;
    private Text _text;

    void Start()
    {
        StartCoroutine(FPS());
        _text = GetComponent<Text>();
    }

    private IEnumerator FPS()
    {
        for (;;)
        {
            // Capture frame-per-second
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            // Display it
            fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
            _text.text = fps;
        }
    }

}
