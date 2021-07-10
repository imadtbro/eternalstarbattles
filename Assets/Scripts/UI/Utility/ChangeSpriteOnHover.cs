using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChangeSpriteOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Image image;
    Sprite defaultSprite;
    public Sprite updatedSprite;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");

        if (updatedSprite != null && image != null) {
            image.sprite = updatedSprite;
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");

        if (defaultSprite != null && image != null) {
            image.sprite = defaultSprite;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       image = GetComponent<Image>();
       defaultSprite = image.sprite; 
    }

}
