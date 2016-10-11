using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}


public class Player : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boudary;

    public float fireRate;
    public GameObject shoot;
    public Transform[] shootSpawns;
    public TouchPad touchpad;
    public FirePad firePad;



    private Quaternion calibrateQuaternion;
    private float nextFire;


    void Start()
    {
       
        ColibrateAcclerometer();
    }

    void Update()
    {
       
        if (firePad.CanFire() && Time.time > nextFire)
        {
           
            nextFire = Time.time + fireRate;
           // GameObject clone = 
            foreach(Transform shootSpawn in shootSpawns)
                 Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);// as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }

    void ColibrateAcclerometer()
    {
        Vector3 acclerationSnapShot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f,0.0f,-1),acclerationSnapShot);
        calibrateQuaternion = Quaternion.Inverse(rotateQuaternion);
      //  Debug.Log(rotateQuaternion);
    }

     Vector3 FixAccleration(Vector3 accleration)
    {
        Vector3 fixedAccleration =  calibrateQuaternion * accleration;
        return fixedAccleration;
    }


    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //  Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Vector3 acclerationRaw = Input.acceleration  ;
        //Vector3 accleration = FixAccleration(acclerationRaw);
        //Vector3 movement = new Vector3(accleration.x, 0.0f, accleration.y);


        Vector2 direction = touchpad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        GetComponent<Rigidbody>().velocity = movement * speed;


        //限制边界
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x,boudary.minX,boudary.maxX),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z,boudary.minZ,boudary.maxZ)
            );

        //飞船角度
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
