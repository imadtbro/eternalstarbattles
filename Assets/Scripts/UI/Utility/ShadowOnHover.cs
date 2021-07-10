using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShadowOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Shadow[] shadow;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");

        if (shadow != null) {
            foreach(Shadow s in shadow) {
                if (!(s is Outline)) {
                    s.enabled = true;
                }
            }            
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");

        if (shadow != null) {
            foreach(Shadow s in shadow) {
                if (!(s is Outline)) {
                    s.enabled = false;
                }
            } 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shadow = GetComponents<Shadow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
