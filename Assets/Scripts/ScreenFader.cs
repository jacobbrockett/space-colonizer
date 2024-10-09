using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [Header("Color")]
    [SerializeField] Image fadeImage;
    [SerializeField] Color fadeColor = Color.black;
    [Header("Transforms")]
    [SerializeField] Transform fadeTransform;
    [Header("Fade Control")]
    [SerializeField] float fadeTime = 1f;
    [SerializeField] bool fadeFromColorOnStart = false;

    float currentFadeTime = 0f;

    bool fading = false;
    bool doneFadingToColor = false;

    void Start(){
        if (fadeFromColorOnStart){
            FadeFromColor();
        }
    }

    public void FadeToColor() // left to right
    {
        if(fading){
            return;
        }

        fading = true;

        StartCoroutine(FadeToColorRoutine());

        IEnumerator FadeToColorRoutine()
        {

            fadeImage.color = fadeColor;

            currentFadeTime = 0f;

            // Set initial scale (width = 0, height remains unchanged)
            fadeTransform.localScale = new Vector3(0, fadeTransform.localScale.y, 1);

            while (currentFadeTime < fadeTime)
            {
                yield return null; // wait a frame

                currentFadeTime += Time.deltaTime;

                fadeTransform.localScale = new Vector3(currentFadeTime / fadeTime, fadeTransform.localScale.y, 1);
            }
            // Final adjustment to ensure it's fully scaled
            fadeTransform.localScale = new Vector3(1, fadeTransform.localScale.y, 1);

            currentFadeTime = 0f;

            fading = false;
            doneFadingToColor = true;

            yield return null;
        }
    }

   
    public void FadeFromColor() // opaque to clear
    {
        if(fading){
            return;
        }

        fading = true;

        StartCoroutine(FadeFromColorRoutine());

        IEnumerator FadeFromColorRoutine()
        {
            fadeImage.color = fadeColor;

            currentFadeTime = 0f;

            // Set initial scale
            fadeTransform.localScale = new Vector3(1, fadeTransform.localScale.y, 1);

            while (currentFadeTime < fadeTime)
            {
                yield return null; // wait a frame

                currentFadeTime += Time.deltaTime;

                fadeTransform.localScale = new Vector3(1f - (currentFadeTime/fadeTime), fadeTransform.localScale.y, 1);
            }
            // Final adjustment to ensure it's fully scaled
            fadeTransform.localScale = new Vector3(0, fadeTransform.localScale.y, 1);

            fading = false;

            yield return null;
        }
    }
    public bool DoneFadingToColor(){
        return doneFadingToColor;
    }

}
