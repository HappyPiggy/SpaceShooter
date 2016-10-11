using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

 
    public GameObject bolt;
    public Transform fireSpawn;

    public float delay;
    public float fireRate;

    private AudioSource audioSource;
	
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	    InvokeRepeating("Fire",delay,fireRate);
	}


    void Fire()
    {
        Instantiate(bolt, fireSpawn.position, fireSpawn.rotation);
        audioSource.Play();
    }
}
