using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDesign : MonoBehaviour
{
    //This script designs the UI of the game

    public TextMeshProUGUI LevelText;             //Current level text
    public TextMeshProUGUI DestroyedBricksText;   //Destroyed + total number of bricks text
    public GameObject GameOverPanel;              //Game Over Panel



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackgroundColor(int level)//Changes background color according to the level
    {
        if (level == 1)
        {
            Camera.main.backgroundColor = new Color32(207, 207, 141, 0); //Yellow
        }
        else if(level == 2)
        {
            Camera.main.backgroundColor = new Color32(141, 207, 206, 0); //Blue
        }
        else if(level == 3)
        {
            Camera.main.backgroundColor = new Color32(212, 176, 207, 0); //Pink
        }
    }
    public void AssignNumberOfBricksUI(int totalBricks)
    {
        DestroyedBricksText.text =  "0/" + totalBricks.ToString();
    }
    public void ChangeNumberOfBricksUI(int destroyedBricks, int totalBricks)
    {
        DestroyedBricksText.text = destroyedBricks.ToString() + "/" + totalBricks.ToString();
    }
    public void ChangeLevelName(int level)
    {
        LevelText.text = "Level " + level.ToString();
    }
    public void OpenGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

}
