using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public Circle ObatacleCircle;

    public float ObstacleRadius = 5.0f;

    void init()
    {
        ObatacleCircle.Radius = ObstacleRadius;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
