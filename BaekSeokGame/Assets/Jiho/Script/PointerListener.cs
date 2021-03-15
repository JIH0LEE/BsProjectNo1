using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pressed = false;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        

    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
