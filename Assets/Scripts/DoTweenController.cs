using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenController : MonoBehaviour
{
    //This script controls DoTween animations.
    //It can be controlled on the editor with SerializeField

    [SerializeField]
    private Vector3 _originalPosition = new Vector3(0, 10f, 0);  
    [SerializeField]
    private Vector3 _targetPosition = new Vector3(0,-1.5f,0);

    [Range(1f,3f), SerializeField]
    private float _moveDuration = 1f;

    [SerializeField]
    private Ease _easeType = Ease.Linear;

    private float _delay=2f; //It is for delay on moving.Incresing it makes object put more accurate
    private float _timer = 0f;
    private bool _isAnimating = false;

    public GameObject MainScriptObject; //To Access MainScript.cs
    public GameObject TableObject;  //Table Object;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAnimating == true)
        {
            
            if (_timer >= 0f)
            {
                
                TableObject.transform.DOMove(_targetPosition, _moveDuration).SetEase(_easeType); //Moves the target position
                _timer -= Time.deltaTime;
            }
            else
            {
                TableObject.transform.position = _targetPosition; //puts the object accurate position in case error or delay
                _isAnimating = false;
                MainScriptObject.transform.GetComponent<MainScript>().MakeGamePlayable();
            }

        }
        
    }

    public void StartAnimation()
    {
        TableObject.transform.position = _originalPosition; //moving starts from _originalPosition
        _timer = _moveDuration + _delay;
        _isAnimating = true;
    }

}
