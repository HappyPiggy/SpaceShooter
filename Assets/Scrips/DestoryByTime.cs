using UnityEngine;
using System.Collections;

public class DestoryByTime : MonoBehaviour
{
    public float leftTime;

    void Start()
    {
      //  Debug.Log(gameObject.name);
        Destroy(gameObject, leftTime);
    }
}
