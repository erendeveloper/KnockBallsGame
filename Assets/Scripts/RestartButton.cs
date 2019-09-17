using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    //Restart button function to restart the game

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public void Restart()
    {
        Debug.Log("Restart button clicked");
        SceneManager.LoadScene(0);
    }
}
