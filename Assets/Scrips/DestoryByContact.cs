using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{

    public GameObject selfExplosion;
    public GameObject palyerExplosion;
    public int getScore;

    private GameController gameController;
    

    void Start()
    {
        GameObject gameControllerObject =GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("can't find GameController Script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (selfExplosion != null)
        {
          //  Debug.Log(other.name);
            Instantiate(selfExplosion, transform.position, transform.rotation);
        }
     
     //   Debug.Log(other.name);

        if (other.CompareTag("Player"))
        {
            Instantiate(palyerExplosion, other.transform.position, other.transform.rotation);
            gameController.Gameover();
        }

      
            gameController.AddScore(getScore);
            Destroy(other.gameObject);
            Destroy(gameObject);
           
      
      
    }
}
