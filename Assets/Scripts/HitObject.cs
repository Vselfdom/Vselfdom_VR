using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitObject : MonoBehaviour {

	public GameObject Ground;
	public GameObject Ball;
	public Text textboxShow;

	private int count=0;

	private bool  Isover=false;
	private int timeOver;

	private SteamVR_TrackedObject trackedObj;//被跟踪的对象
	
	//Device 属性能够很方便地访问到这个手柄。通过所跟踪的对象的索引来访问控制器的 input，并返回这个 input。
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}
	void Start () 
	{
		timeOver=(int)Time.time+60;
	}

	// 每帧更新
	void Update () 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();//对跟踪对象进行实例化，移动和旋转都会被 HTC Vive 跟踪到并传递到虚拟世界
		//当你按下扳机时，这会打印到控制台。
		if (Controller.GetHairTriggerDown())
		{
			Debug.Log(gameObject.name + " Trigger Press");
			Transform camera=Camera.main.transform;
			Ray ray;
			RaycastHit[] hits;
			GameObject hitObject;
			Debug.DrawRay(camera.position,camera.rotation*Vector3.forward*100.0f);
			ray=new Ray(camera.position,camera.rotation*Vector3.forward);
			hits=Physics.RaycastAll(ray);
			if(hits.Length>0)
			{
				RaycastHit hit=hits[hits.Length-1];
				hitObject=hit.collider.gameObject;
				//Debug.Log("Hit (x,y,z):"+hit.point.ToString("F2"));
				if(hitObject!=Ground)
				{
					if(Isover==false)
					{
						
						Debug.Log(hitObject.transform.localScale);
						if(hitObject.transform.localScale==new Vector3(1.0f,1.0f,1.0f))
							count=count+10;
						else if(hitObject.transform.localScale==new Vector3(0.9f,0.9f,0.9f))
							count=count+5;
						else
							count++;
					}
					
					Destroy(hitObject);
					Debug.Log("得分： "+count);
					//GameObject.Find("VisorCanvas/Text").GetComponent<Text> ().text="打中个数： "+count;
				}

			}
		}
		//如果松开扳机，这会打印到控制台
		if (Controller.GetHairTriggerUp())
		{
			Debug.Log(gameObject.name + " Trigger Release");
		}
		int  lesstime=timeOver-(int)Time.time;
		if(lesstime>0)
			textboxShow.text = "得分： "+count+" 分 "+" \t剩余时间： "+lesstime+" 秒";  
		else
		{
			Isover=true;
		}
		if(Isover==true)
		{
			textboxShow.text = "游戏结束! 成绩:"+count+"分";  
			textboxShow.fontSize=90;
			
		}
	}
}
