using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int dodgeCount = 0;
    public int currentLevel = 0;
    public int passingCount = 3; //how many times to dodge

    public static GameManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null) //IF THERE IS NO INSTANCE, LET THIS INSTANCE EXIST
        {
            instance = this; //this refers to the object you are currently INSIDE OF
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {if (dodgeCount == passingCount) //if you dodge enough times, you go to next level!
        {
            //how many times you dodged! 
            currentLevel++; //so that the level goes up by 1
            dodgeCount = 0;
            passingCount = passingCount * 2; //makes the next required score HIGHER
            SceneManager.LoadScene(currentLevel);
        }
    }
}