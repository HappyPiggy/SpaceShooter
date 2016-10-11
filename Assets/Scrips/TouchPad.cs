using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public float smoothing;


    private Vector2 orign;
    private Vector2 direction;
    private Vector2 smoothDirect;

    private int pointerID;
    private bool isTouch;

    void Awake()
    {
        direction = Vector2.zero;
        isTouch = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isTouch)
        {
            isTouch = true;
            pointerID = eventData.pointerId;
          //  Debug.Log(pointerID);
            orign = eventData.position;

        }
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerID)
        {
            direction = Vector2.zero;
            isTouch = false;
        }
     
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerID)
        {
            Vector2 directionRaw = eventData.position - orign;
            direction = directionRaw.normalized;
        }
        
    }

    public Vector2 GetDirection()
    {
       // Debug.Log(smoothDirect);
        smoothDirect = Vector2.MoveTowards(smoothDirect, direction, smoothing);
        return smoothDirect;
    }
}
