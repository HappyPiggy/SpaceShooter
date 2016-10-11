using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour
{

	public Vector2 startTime;
    public Vector2 maneuverTime;
    public Vector2 waitTime;

    public float dodge;
    public float smoothing;
    public float tilt;

    public Boundary boudary;

    private Rigidbody rb;
    private float targetManeuver;
    private float orignSpeed;


	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    orignSpeed = rb.velocity.z;
		StartCoroutine(Evade());
	}

	private IEnumerator Evade()
	{
		yield return new WaitForSeconds(Random.Range(startTime.x,startTime.y));

	    while (true)
	    {
	        targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
	        yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
	        targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(waitTime.x, waitTime.y));
	    }
	}


	void FixedUpdate ()
	{
	    float newManeuver = Mathf.MoveTowards(rb.velocity.x,targetManeuver,Time.deltaTime * smoothing);
	    rb.velocity=new Vector3(newManeuver, 0.0f, orignSpeed);
	    rb.position=new Vector3
            (
	           Mathf.Clamp(rb.position.x,boudary.minX,boudary.maxX) , 
	           0.0f,
               Mathf.Clamp(rb.position.z, boudary.minZ, boudary.maxZ)
	        );

	    rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * -tilt);
	}
}
