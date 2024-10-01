using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color visitColor;
    [SerializeField] Color colonizedColor;
    SpriteRenderer spriteRenderer;
    [SerializeField] int visitors = 0;

    [Header("Colonization")]
    [SerializeField] Transform colonizeProgressTransform;
    [SerializeField] SpriteRenderer colonizeProgressSpriteRenderer;
    [SerializeField] float colonizeTime = 5f;
    float colonizeProgressPercentage = 0f;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;

    }

    public void SetColonizeProgress(float t)
    {
        colonizeProgressTransform.localScale = Vector3.one * t;
    }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     // Once per fixed update

    //     colonizeProgressPercentage += Time.fixedDeltaTime * colonizeSpeed;

    //     if(colonizeProgressPercentage > 1)
    //     {
    //         colonizeProgressPercentage = 1;
    //     }

    //     SetColonizeProgress(colonizeProgressPercentage);
    // }

    void Update()
    {
        colonizeProgressPercentage += (Time.deltaTime / colonizeTime) * visitors;

        if(colonizeProgressPercentage > 1)
        {
            colonizeProgressSpriteRenderer.color = colonizedColor;
            colonizeProgressPercentage = 1;
        }

        SetColonizeProgress(colonizeProgressPercentage);
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Spaceship"))
        {
            spriteRenderer.color = visitColor;
            visitors+=1;
        }
        

        // other.GetComponent<SpriteRenderer>().color = Color.black; // change ship color
        // other.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // make ship small
    }

    void OnTriggerExit2D(Collider2D other){

        if(other.CompareTag("Spaceship"))
        {
            visitors-=1;
            if(visitors < 1)
            {
                spriteRenderer.color = defaultColor;
                visitors = 0;
            }
        }
        

        // other.GetComponent<SpriteRenderer>().color = Color.white; // change ship color
        // other.transform.localScale = Vector3.one; // make ship normal size again
    }

}
