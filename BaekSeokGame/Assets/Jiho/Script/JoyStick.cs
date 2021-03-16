using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour,IPointerUpHandler,IDragHandler, IPointerDownHandler
{
    RectTransform rect;

    Vector2 touch=Vector2.zero;
    public RectTransform handler;
   
    float widthHalf;

    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / widthHalf;
        if (touch.magnitude > 1)
        {
            touch = touch.normalized;
        }
        handler.anchoredPosition = touch * widthHalf;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handler.anchoredPosition = Vector2.zero;
    }



    
    void Start()
    {
       
        rect = GetComponent<RectTransform>();
        widthHalf= rect.sizeDelta.x * 0.5f;
    }

    
    void Update()
    {
        
    }
}
