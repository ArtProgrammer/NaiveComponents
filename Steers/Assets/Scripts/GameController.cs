using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Transform Agent;

    public Steering AgentSteer;

    public List<Steering> AgentsList { get; set; }

    public string AgentsName = "Agents";

    public int AgentsCount { get; set; }

    public string ObstaclesName = "Obstacles";

    public List<Obstacle> ObstacleList { get; set; }

    public int ObstacleCount { get; set; }

    private GameController() { }

    public static GameController instance
    {
        get
        {
            return Nested.instance;
        }
    }

    private class Nested
    {
        static Nested() { instance.init(); }
        internal static readonly GameController instance =
            new GameController();
    }

    void init()
    {
        if (Agent)
            AgentSteer = Agent.GetComponent<Steering>();

        AgentsList = new List<Steering>();

        Transform agentsTrans = GameObject.Find(AgentsName).transform;

        AgentsCount = agentsTrans.childCount;

        for (int i = 0; i < AgentsCount; ++i)
        {
            AgentsList.Add(agentsTrans.GetChild(i).GetComponent<Steering>());
        }

        ObstacleList = new List<Obstacle>();

        Transform obstacleTrans = GameObject.Find(ObstaclesName).transform;
        ObstacleCount = obstacleTrans.childCount;

        for (int i = 0; i < ObstacleCount; ++i)
        {
            ObstacleList.Add(obstacleTrans.GetChild(i).GetComponent<Obstacle>());
        }

        Application.targetFrameRate = -1;
    }

    // Use this for initialization
    void Start () {
        init();
    }
	
	// Update is called once per frame
	void Update () {
        handleInput();
    }

    void handleInput()
    {
        bool gotTargetPos = false;
        Vector3 touchpos = Vector3.zero;
        GameObject hitObj = null;

#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(1))
            gotTargetPos =
                getTouchPoint(ref touchpos,
                                Input.mousePosition,
                                out hitObj);
#else
			if (Input.touchCount > 0 && 
                Input.GetTouch(0).phase == TouchPhase.Began)
				gotTargetPos = 
                    getTouchPoint(ref battleTouchPosition, 
                                    Input.GetTouch(0).position, 
                                    out hitObj);
#endif

        // touchpos
        if (gotTargetPos)
        {
            touchpos.y = Agent.position.y;
            AgentSteer.setTargetPosition(ref touchpos);
        }
    }

    bool getTouchPoint(ref Vector3 point,
                            Vector3 screenPoint,
                            out GameObject hitObj)
    {
        hitObj = null;

        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider != null)
        {
            if (hit.collider.gameObject.transform.parent != null)
                hitObj = hit.collider.gameObject.transform.parent.gameObject;

            point.x = hit.point.x;
            point.y = 0;
            point.z = hit.point.z;

            return true;
        }

        return false;
    }

    void OnGUI()
    {
       
    }
}
