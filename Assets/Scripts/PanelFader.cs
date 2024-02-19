using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    public float duration = 3.0f;

    public void FadeOut()
    {
        var canGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeCanvas(canGroup, 1, 0, duration));
    }

    public void FadeIn()
    {
        var canGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeCanvas(canGroup, 0, 1, duration));
    }

    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
    {
        var startTime = Time.time;
        var endTime = Time.time + duration;
        var elapsedTime = 0f;

        canvas.alpha = startAlpha;

        while (Time.time <= endTime)
        {
            elapsedTime = Time.time - startTime;
            var percentage = 1 / (duration / elapsedTime);

            if (startAlpha > endAlpha)
            {
                canvas.alpha = startAlpha - percentage;

            }
            else
            {
                canvas.alpha = startAlpha + percentage;
            }

            yield return new WaitForEndOfFrame();
        }

        canvas.alpha = endAlpha;
    }
}
