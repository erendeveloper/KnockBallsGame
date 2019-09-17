using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksDesign : MonoBehaviour
{
    //This script design the bricks according to the scriptable objects and thir level

    public GameObject MainScriptObject; //To access MainScript.cs

    public GameObject Table;  //Table Object

    public BricksScriptableObject[] BrickContainers; //Scriptable Object list contains bricks designs

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBricks(int level)//select bricks dsign according to the level
    {
            GameObject containerObject = Instantiate(BrickContainers[level-1].BricksContainer) as GameObject;
            containerObject.transform.parent = Table.transform;
            containerObject.transform.localPosition = Vector3.zero;
            int numberOfBricks = containerObject.transform.childCount;
            MainScriptObject.transform.GetComponent<MainScript>().ChangeTotalBricks(numberOfBricks);
    }
    public void AssignGravity() //assign gravity to bricks' rigidbody.they are added after animation.So they dont fall down while moving.
    {
        GameObject container = GameObject.FindGameObjectWithTag("Container"); //Container of the bricks
        foreach (Transform child in container.transform)
        {
            child.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    public int GetNumberOfLevels() //Total number of levels in the game
    {
        return BrickContainers.Length;
    }
}
