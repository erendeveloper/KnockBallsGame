using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //This script manages each brick

    private GameObject _mainScriptObject; //To access MainScript.cs

    private float floorPosition=-10f;   //Floor position to destroy the brick after falling down

    // Start is called before the first frame update
    void Start()
    {
        _mainScriptObject = GameObject.Find("Main Script");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= floorPosition)
        {
            _mainScriptObject.transform.GetComponent<MainScript>().AddDestroyedBricks();
            Debug.Log("Brick destroyed");
            Destroy(this.gameObject);
        }
    }
}
