using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] public UnityEngine.UI.Image childImageToggle;
    [SerializeField] public Transform childImageMove;
    [SerializeField] public float movementY = 4f;

    [SerializeField] public float buttonSpeed = 0.1f;
    [SerializeField] public AudioSource buttonClick;

    private bool isImageClicked = false;

    public void OnMouseDown()
    {
        
        if (!isImageClicked)
        {
            // Disable the image instead of destroying it:
            childImageToggle.enabled = false;

            // Move the child element:
            childImageMove.transform.Translate(0f, -movementY, 0f);

            buttonClick.Play();
            isImageClicked = true;
            

            Invoke("OnMouseUp", buttonSpeed);
        }
    }

    public void OnMouseUp()
    {
        if (isImageClicked)
        {
            
            // Re-enable the image:
            childImageToggle.enabled = true;

            // Move the child element back to its original position:
            childImageMove.transform.Translate(0f, movementY, 0f);

            isImageClicked = false;
        }
    }

}
