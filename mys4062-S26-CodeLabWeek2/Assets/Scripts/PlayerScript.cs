using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = this;
            DontDestroyOnLoad(gameObject);
            //so that if another player spawns, it will destroy itself
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}