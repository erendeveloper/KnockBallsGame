using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //This script manages each ball

    private const float _shotForce = 300f; //Force to add to ball
    private const float _timerValue = 3f;  //life time of the ball
    private float _timer; //timer for the ball


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ball shooted");
        _timer = _timerValue;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            AddToPool();
        }
    }

    public void AddForceToBall(Vector3 shotPosition) //Shoots the ball
    {
        
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(shotPosition);
        this.gameObject.transform.GetComponent<Rigidbody>().AddForce(viewPosition*_shotForce);
    }

    //Object Pooling.Adds unused balls to the pool.No need to intantitate new balls, so performance utilization
    void AddToPool()
    {
        GameObject ballPool = GameObject.Find("Ball Pool");
        this.gameObject.SetActive(false);
        this.transform.parent = ballPool.transform;
    }
    public void ResetBall() //Resets ball to be used again
    {
        _timer = _timerValue;
        this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
