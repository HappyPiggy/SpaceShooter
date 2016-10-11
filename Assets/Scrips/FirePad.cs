using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FirePad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private int pointerID;
    private bool isTouch;
    private bool canFire;

    void Awake()
    {
        isTouch = false;
        canFire = false;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isTouch)
        {
            isTouch = true;
            pointerID = eventData.pointerId;
            canFire = true;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerID)
        {
            isTouch = false;
            canFire = false;
        }

    }

    public bool CanFire()
    {
        return canFire;
    }
}
