using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    //This is General Manager Script of the game.All reqeuest made via this script.

    private int _level=0;                               //current level
    private bool _isClickActive = false;                //game can be played with ball
    private int _totalBricks = 0;                       //total bricks in the level
    private int _destroyedBricks = 0;                   //bricks fallen down
    private float _levelTimer = 0;                      //time to pass the level
    private float _allLevelsTimer = 0;                  //time to complete the game
    private bool _isLevelTimerActive = false;           //opens level timer

    //Objects to access their scripts
    public GameObject DoTweenControllerObject;          //DoTweenController.cs
    public GameObject BricksDesignObject;               //BricksDesign.cs 
    public GameObject UIDesignObject;                   //UIDesign.cs

    public GameObject Table;                            //Table Object

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
        selectLevelFromPrefs();     //Selects the level last opened level
        LevelStart();               //Starts the level
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer for the level playing
        if (_isLevelTimerActive == true)
        {
            _levelTimer += Time.deltaTime;
        }
    }

    //Selects the level last opened level
    void selectLevelFromPrefs()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            _level = PlayerPrefs.GetInt("Level")-1;
        }
    }

    //Starts the level
    void LevelStart()
    {
        _isClickActive = false; //nonclickable  until the level is ready
        _level++;  //first level start from 0 and then other levels increasing
        int totalLevel = BricksDesignObject.transform.GetComponent<BricksDesign>().GetNumberOfLevels(); //total number of level in the game
        if (_level != (totalLevel+1)) //more than the level gets game over
        {
            //makes the level ready to be played
            PlayerPrefs.SetInt("Level", _level);
            Debug.Log("Level " + _level.ToString() + " started.");
            UIDesignObject.transform.GetComponent<UIDesign>().ChangeBackgroundColor(_level);
            BricksDesignObject.transform.GetComponent<BricksDesign>().SelectBricks(_level);
            UIDesignObject.transform.GetComponent<UIDesign>().ChangeLevelName(_level);
            UIDesignObject.transform.GetComponent<UIDesign>().AssignNumberOfBricksUI(_totalBricks);
            DoTweenControllerObject.GetComponent<DoTweenController>().StartAnimation();
        }
        else //game over
        {
            PlayerPrefs.SetInt("Level", 1);//first level after completing
            Debug.Log("Game has been completed in " + Mathf.Floor(_allLevelsTimer).ToString() + " seconds.");
            UIDesignObject.transform.GetComponent<UIDesign>().OpenGameOverPanel();
        }
    }

    public void MakeGamePlayable() //ball can be shhoted
    {
        BricksDesignObject.transform.GetComponent<BricksDesign>().AssignGravity();
        _isClickActive = true;
    }

    public bool Get_isClickActive() //clickable state
    {
        return _isClickActive;
    }
    public void ChangeTotalBricks(int total) //assigns total number of the bricks in the new level
    {
        _totalBricks = total;
        _destroyedBricks = 0;
    }
    public void AddDestroyedBricks() //Increases the number of bricks fallen down
    {
        _destroyedBricks++;
        UIDesignObject.transform.GetComponent<UIDesign>().ChangeNumberOfBricksUI(_destroyedBricks,_totalBricks);
        //after falling all bricks it destroys their container to put new one
        if (_destroyedBricks == _totalBricks)
        {
            GameObject container = GameObject.FindGameObjectWithTag("Container");
            Destroy(container);
            LevelStart();
        }
    }
    public void SelectBricks() //Selects the bricks according to the new level
    {
        BricksDesignObject.transform.GetComponent<BricksDesign>().SelectBricks(_level);
    }
    void activateLevelTimer() //Activates level timer
    {
        _levelTimer = 0f;
        _isLevelTimerActive = true;
    }
    void stopLevelTimer() //Stops level timer
    {
        _isLevelTimerActive = false;
        _allLevelsTimer += _levelTimer;
        Debug.Log("Level " + _level.ToString() + " has been completed in " + Mathf.Floor(_levelTimer).ToString() + " seconds.");
    }
}
