using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPostion : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (RePostionWithDelay());
	}
	IEnumerator RePostionWithDelay()
	{
		while(true)
		{
			SetRandomPostion();
			//yield return  new WaitForFixedUpdate();
			yield return new WaitForSeconds(3);

		}
	}
	void SetRandomPostion()
	{
		float x=Random.Range(-15.0f,15.0f);
		float z=Random.Range(-15.0f,15.0f);
		Debug.Log("X,Z : "+x.ToString("F2")+","+z.ToString("F2"));
		transform.position=new Vector3(x,0.0f,z);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
