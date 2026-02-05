using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCubeScript : MonoBehaviour


{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Game Over!"); //i cant figure out how to get the code to destroy ALL objects, even multiples
        }

        if (other.gameObject.name == "Platform")
        {
            Vector3 newPosition = new Vector3(
                UnityEngine.Random.Range(-9, 9), 
                UnityEngine.Random.Range(14, 25), //make it respawn randomly within this range 
                1);
            transform.position  = newPosition;
            GameManager.instance.dodgeCount++;//access gamemanager dodgecount to add to it thank you singletons
            Debug.Log(GameManager.instance.dodgeCount);
        }
    }
}