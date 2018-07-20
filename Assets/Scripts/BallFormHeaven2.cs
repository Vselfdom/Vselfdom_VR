using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFormHeaven2 : MonoBehaviour {

	public GameObject ball;
	public float startHeight =10f;
	public float fireInterval=0.5f;
	private float nextBallTime=0.0f;
	public int countball=10;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time>nextBallTime)
		{
			nextBallTime=Time.time+fireInterval;
			for(int i=0;i<countball;i++)
			{
				Vector3 position=new Vector3(Random.Range(-15.0f,15.0f),startHeight,Random.Range(-15.0f,15.0f));
				GameObject temp=Instantiate(ball,position,Quaternion.identity);
			}
		}
	}
}
