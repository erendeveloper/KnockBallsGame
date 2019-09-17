using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lean.Touch
{
	/// <summary>This component allows you to spawn a prefab at the specified world point.
	/// NOTE: To trigger the prefab spawn you must call the Spawn method on this component from somewhere.</summary>
	[HelpURL(LeanTouch.HelpUrlPrefix + "LeanSpawn")]
	[AddComponentMenu(LeanTouch.ComponentPathPrefix + "Spawn")]
	public class BallSpawn : MonoBehaviour
	{
        /// <summary>The prefab that this component can spawn.</summary>
        [Tooltip("The prefab that this component can spawn.")]

        //This script is for instantiating and positioning balls


        public GameObject MainScriptObject; //To access MainScript.cs

		public GameObject BallPrefab;

        public GameObject BallPool;

		/// <summary>This will spawn Prefab at the specified finger based on the ScreenDepth setting.</summary>
		public void Spawn(Vector3 position)
		{
            bool _isSpawningActive = MainScriptObject.transform.GetComponent<MainScript>().Get_isClickActive();

            if (_isSpawningActive==true)
			{
                GameObject ball;

                if (BallPool.gameObject.transform.childCount == 0) //instantitaes new ball
                {
                    ball = Instantiate(BallPrefab);
                    
                }
                else //Select balls from to pool.
                {
                    ball = BallPool.transform.GetChild(0).gameObject;
                    ball.transform.parent = null;
                    ball.SetActive(true);
                    ball.GetComponent<Ball>().ResetBall();           
                }
                ball.transform.position = position; //position is reached from Lean Touch
                ball.transform.GetComponent<Ball>().AddForceToBall(position);
            }

		}

    }
}