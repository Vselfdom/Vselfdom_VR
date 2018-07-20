using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatObject : MonoBehaviour {

	public GameObject[] gamehit=new GameObject[10];

	public float fireInterval=1f;
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
				Vector3 position=new Vector3(Random.Range(-15.0f,15.0f),Random.Range(1.0f,10.0f),Random.Range(-15.0f,15.0f));
				int count=(int)Random.Range(0.0f,5.0f);
				GameObject temp=Instantiate(gamehit[count],position,Quaternion.identity);
				//temp.transform.Rotate(Random.Range(0.0f,180.0f), Random.Range(0.0f,180.0f), Random.Range(0.0f,180.0f));
				float size=Random.Range(0.0f,0.8f);
				temp.transform.localScale=new Vector3 (size,size,size);
			}
		}
	}
}
