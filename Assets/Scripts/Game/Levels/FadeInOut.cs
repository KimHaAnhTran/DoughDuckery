using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float fadeTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (fadeIn){
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeTime * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= fadeTime * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
        //fadeOut = false;
    }
    public void FadeOut()
    {
        fadeOut = true;
        //fadeIn = false;
    }
}
