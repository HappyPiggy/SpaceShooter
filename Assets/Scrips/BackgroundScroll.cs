using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{

	public float scrollSpeed;
	public float tileSize;
	private Vector3 startPosition ;

	void Start()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
	   

		float newPosition= Mathf.Repeat(Time.time*scrollSpeed,tileSize);
	  //  Debug.Log(newPosition);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
