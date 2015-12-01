using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneCtrl : MonoBehaviour {

    public List<Transform> ObjList = new List<Transform>();
    
    public float CircleRadius = 10.0f;
    
    public float StartAngle = 0.0f;
    
    public void init()
    {
	Transform objects = GameObject.Find("Objects").transform;
	
	foreach(Transform obj in objects) {
	    ObjList.Add(obj);
	}
	
	Debug.Log("Object count: " + ObjList.Count);
	
	setCirclePoses();
    }

    private Vector3 Pos = Vector3.zero;
    
    void setCirclePoses()
    {
	int count = ObjList.Count;
	
	if (count > 0)
	{
	    float angleStep = 360.0f / count;
	    float curAngle = StartAngle;
	    for (int i = 0; i < count; ++i)
	    {
		curAngle = StartAngle + angleStep * i;
		Pos.x = 
		    CircleRadius * Mathf.Cos(curAngle * Mathf.Deg2Rad);
		Pos.z = 
		    CircleRadius * Mathf.Sin(curAngle * Mathf.Deg2Rad);
		ObjList[i].transform.position = Pos;
	    }
	}
    }

    // Use this for initialization
    void Start () {
	init();
    }
	
    // Update is called once per frame
    void Update () {
	Debug.Log(ObjList[0].eulerAngles);
    }
}
