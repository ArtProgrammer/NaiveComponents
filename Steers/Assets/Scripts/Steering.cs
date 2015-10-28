using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Path
{
    List<Vector3> Nodes = new List<Vector3>();

    public void addNode(Vector3 val)
    {
        Nodes.Add(val);
    }

    public Vector3 getNodeByIndex(int index)
    {
        return Nodes[index];
    }

    public void getNodeByIndex(int index, out Vector3 val)
    {
        val = Nodes[index];
    }

    public List<Vector3> getNodes()
    {
        return Nodes;
    }

    public void getNodes(ref List<Vector3> list)
    {
        list = Nodes;
    }

    public void clear()
    {
        Nodes.Clear();
    }
}

public class Steering : MonoBehaviour {

    private Vector3 TargetPos;

    public float MAX_VELOCITY = 30.0f;

    public float MAX_FORCE = 100.0f;

    public float SlowingRadius = 3.0f;

    public Vector3 Velocity = Vector3.zero;

    public float Mass = 1.0f;

    public Vector3 SteerForce = Vector3.zero;

    public bool isArriveOn = false;

    public bool isFleeOn = false;

    public bool isSeekOn = false;

    public bool isWander = false;

    public float CircleDistance = 10.0f;

    public float CircleRadius = 5.0f;

    public float WanderChange = 5.0f;

    public float WanderAngle = 0.0f;

    //public float DisPursuer2Target = 10.0f;

    public Transform Target;

    public Transform Leader;

    public bool isPursuitOn = false;

    public bool isEvadeOn = false;

    public bool isFollowLeaderOn = false;

    public bool isObstacleAvoidanceOn = false;

    public bool isPathFollowingOn = false;

    public bool isQueueOn = false;

    public float Radius = 5.0f;

    public float Separation_Radius = 3.0f;

    public float MAX_SEPARATION = 50.0f;

    public float LEADER_BEHIND_DIST = 5.0f;

    public float LEADER_SIGHT_RADIUS = 5.0f;
    //public List<Steering> AgentsList;

    public float MAX_SEE_AHEAD = 10.0f;

    public float MAX_AVOID_FORCE = 100.0f;

    private Path path;

    private int CurNode = 0;

    private int PathDir = 1;

    public Transform PathTrans;

    public float MAX_QUEUE_AHEAD = 3.0f;

    public float MAX_QUEUE_RADIUS = 2.0f;

    void init()
    {
        path = new Path();

        if (PathTrans)
        {
            for (int i = 0; i < PathTrans.childCount; ++i)
            {
                path.addNode(PathTrans.GetChild(i).position);
            }
        }
        
    }

    // Use this for initialization
    void Start () {
        init();
    }
	
    void calculateSteer()
    {
        if (isArriveOn)
        {
            SteerForce += arrival(ref TargetPos);
        }

        if (isFleeOn)
        {
            SteerForce += flee(ref TargetPos);
        }

        if (isSeekOn)
        {
            SteerForce += seek(ref TargetPos);
        }

        if (isWander)
        {
            SteerForce += wander();
        }

        if (isPursuitOn && Target != null)
        {
            Steering steering = Target.GetComponent<Steering>();
            if (steering != null)
                SteerForce += pursuit(steering);
        }

        if (isEvadeOn && Target != null)
        {
            Steering steering = Target.GetComponent<Steering>();
            if (steering != null)
                SteerForce += evade(ref steering);
        }

        if (isFollowLeaderOn && Leader != null)
        {
            Steering steering = Leader.GetComponent<Steering>();
            if (steering != null)
                SteerForce += followLeader(ref steering);
        }

        if (isObstacleAvoidanceOn)
        {
            SteerForce += obstacleAvoidance();
        }

        if (isPathFollowingOn)
        {
            SteerForce += pathFollowing();
        }

        if (isQueueOn)
        {
            SteerForce += queue() * 0.3f;
        }
    }

	// Update is called once per frame
	void Update () {

        calculateSteer();

        updatePosition(ref SteerForce);

        if (!Mathf.Approximately(Velocity.sqrMagnitude, 0.0f))
        {
            transform.rotation =
            Quaternion.LookRotation(Velocity); 
        }

        clearSteerForce();
    }

    void clearSteerForce()
    {
        SteerForce = Vector3.zero;
    }

    void updatePosition(ref Vector3 steer)
    {
        truncate(ref steer, MAX_FORCE);
        steer /= Mass;

        Velocity += steer;
        truncate(ref Velocity, MAX_VELOCITY);

        Velocity.y = 0.0f;
        transform.position += Velocity * Time.deltaTime;
    }

    public void setTargetPosition(ref Vector3 pos)
    {
        TargetPos = pos;
    }

    private void truncate(ref Vector3 orgin, float factor)
    {
        float i = factor / orgin.magnitude;
        orgin *= i < 1.0f ? i : 1.0f;
    }

    private Vector3 seek(ref Vector3 pos)
    {
        Vector3 desiredVelocity = 
            Vector3.Normalize(pos - transform.position) * MAX_VELOCITY;

        Vector3 steerForce = desiredVelocity - Velocity;

        //truncate(ref steerForce, MAX_FORCE);
        //steerForce /= Mass;

        return steerForce;
    }

    private Vector3 flee(ref Vector3 pos)
    {
        Vector3 desiredVelocity =
            Vector3.Normalize(transform.position - pos) * MAX_VELOCITY;

        Vector3 steerForce = desiredVelocity - Velocity;

        //truncate(ref steerForce, MAX_FORCE);
        //steerForce /= Mass;

        return steerForce;
    }

    private Vector3 arrival(ref Vector3 pos)
    {
        Vector3 desiredVelocity = pos - transform.position;
        float dis = desiredVelocity.magnitude;

        float factor = dis / SlowingRadius;
        desiredVelocity = Vector3.Normalize(desiredVelocity) *
                MAX_VELOCITY * (factor < 1.0f ? factor : 1.0f);

        Vector3 steer = desiredVelocity - Velocity;
        //truncate(ref steer, MAX_FORCE);
        //steer /= Mass;

        return steer;
    }

    /// <summary>
    /// seek + randomness
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private Vector3 wander()
    {
        Vector3 circle = Vector3.zero;
        circle.x = Velocity.x;
        circle.y = Velocity.y;
        circle.z = Velocity.z;

        circle.Normalize();
        circle *= CircleDistance;

        Vector3 displcement = new Vector3(0, 0, -1);
        displcement *= CircleRadius;
        
        setAngle(ref displcement, WanderAngle / Mathf.Rad2Deg);

        WanderAngle += (Random.value - 0.5f) * WanderChange;

        Vector3 steer = circle + displcement;

        return steer;
    }

    private void setAngle(ref Vector3 vec, float angle)
    {
        float len = vec.magnitude;
        vec.x = Mathf.Sin(angle) * len;
        vec.x = Mathf.Cos(angle) * len;
    }

    private Vector3 pursuit(Steering target)
    {
        float t = (target.transform.position - transform.position).magnitude / MAX_VELOCITY;
        Vector3 futurePos = target.transform.position + target.Velocity * t;
        return seek(ref futurePos);
    }

    private Vector3 evade(ref Steering target)
    {
        float t = (target.transform.position - transform.position).magnitude / MAX_VELOCITY;
        Vector3 futurePos = target.transform.position + target.Velocity * t;
        return flee(ref futurePos);
    }

    private Vector3 separation()
    {
        Vector3 force = Vector3.zero;

        int neighborCount = 0;

        for (int i =0; i < GameController.instance.AgentsCount; ++i)
        {
            Steering st = GameController.instance.AgentsList[i];
            if (st != this && 
                !(Vector3.SqrMagnitude(st.transform.position - transform.position) > 
                Separation_Radius * Separation_Radius))
            {
                force.x += st.transform.position.x - transform.position.x;
                force.z += st.transform.position.z - transform.position.z;
                neighborCount++;
            }
        }

        if (neighborCount != 0)
        {
            force /= -neighborCount;
        }

        force.Normalize();
        force *= MAX_SEPARATION;

        return force;
    }

    private bool isOnLeaderSight(ref Steering leader, ref Vector3 leadAhead)
    {
        return !(Vector3.SqrMagnitude(leadAhead - transform.position) > LEADER_SIGHT_RADIUS) ||
            !(Vector3.SqrMagnitude(leader.transform.position - transform.position) > LEADER_SIGHT_RADIUS);
    }

    private Vector3 followLeader(ref Steering leader)
    {
        Vector3 tv = Vector3.zero;
        tv.x = leader.Velocity.x;
        tv.y = leader.Velocity.y;
        tv.z = leader.Velocity.z;

        Vector3 force = Vector3.zero;

        tv.Normalize();
        tv *= LEADER_BEHIND_DIST;
        Vector3 ahead = leader.transform.position + tv;

        tv *= -1;
        Vector3 behind = leader.transform.position + tv;

        if (isOnLeaderSight(ref leader, ref ahead))
        {
            force += evade(ref leader);
        }
        force += arrival(ref behind);

        force += separation();

        return force;
    }

    private bool lineIntersectsCircle(ref Vector3 ahead, 
                                      ref Vector3 ahead2,
                                      ref Vector3 pos,
                                      ref Obstacle obstacle)
    {
        return !(Vector3.SqrMagnitude(obstacle.transform.position - ahead) > 
                obstacle.ObstacleRadius * obstacle.ObstacleRadius) ||
            !(Vector3.SqrMagnitude(obstacle.transform.position - pos) >
                obstacle.ObstacleRadius * obstacle.ObstacleRadius) ||
            !(Vector3.SqrMagnitude(obstacle.transform.position - ahead2) > 
                obstacle.ObstacleRadius * obstacle.ObstacleRadius);
    }

    private Obstacle findThreateningObstacle(ref Vector3 ahead, 
                                             ref Vector3 ahead2,
                                             ref Vector3 pos)
    {
        Obstacle mostThreatening = null;

        Obstacle obstacle = null;
        for (int i = 0; i < GameController.instance.ObstacleList.Count; ++i)
        {
            obstacle = GameController.instance.ObstacleList[i];
            bool collistion = 
                lineIntersectsCircle(ref ahead, 
                                     ref ahead2, 
                                     ref pos, 
                                     ref obstacle);

            if (collistion && (mostThreatening == null || 
                (Vector3.SqrMagnitude(transform.position - 
                obstacle.transform.position)
                < Vector3.SqrMagnitude(transform.position - 
                mostThreatening.transform.position))))
            {
                mostThreatening = obstacle;
            }
        }

        return mostThreatening;
    }

    private Vector3 obstacleAvoidance()
    {
        Vector3 force = Vector3.zero;

        float dynamic_length = Velocity.magnitude / MAX_VELOCITY;

        Vector3 ahead = 
            transform.position + 
            Velocity.normalized * MAX_SEE_AHEAD * dynamic_length;

        Vector3 ahead2 = 
            transform.position + 
            Velocity.normalized * MAX_SEE_AHEAD * dynamic_length * 0.5f;

        Vector3 pos = transform.position;
        Obstacle mostThreatening = 
            findThreateningObstacle(ref ahead, ref ahead2, ref pos);

        if (mostThreatening != null)
        {
            force.x = ahead.x - mostThreatening.transform.position.x;
            force.z = ahead.z - mostThreatening.transform.position.z;

            force.Normalize();
            force *= MAX_AVOID_FORCE;
        }

        return force;
    }

    private Vector3 pathFollowing()
    {
        bool gotPos = false;
        Vector3 targetPos = transform.position;

        if (path != null)
        {
            var nodes = path.getNodes();

            targetPos = nodes[CurNode];

            gotPos = true;

            if (Vector3.SqrMagnitude(transform.position - targetPos) <= 4.0f)
            {
                CurNode += PathDir;

                if (CurNode >= nodes.Count || CurNode < 0)
                {
                    PathDir *= -1;
                    CurNode += PathDir;
                }
            }
        }

        return gotPos ? seek(ref targetPos) * 10.0f : Vector3.zero;
    }

    private Steering getNeighborAhead()
    {
        Steering ret = null;

        Vector3 qa = Velocity;

        qa.Normalize();

        qa *= MAX_QUEUE_AHEAD;

        Vector3 ahead = transform.position + qa;

        for (int i = 0; i < GameController.instance.AgentsCount; ++i)
        {
            Steering neigh = GameController.instance.AgentsList[i];
            float sqrDis = Vector3.SqrMagnitude(ahead - neigh.transform.position);
            if (neigh != null && sqrDis <= MAX_QUEUE_RADIUS * MAX_QUEUE_RADIUS)
            {
                ret = neigh;
                break;
            }
        }

        return ret;
    }

    private Vector3 queue()
    {
        Vector3 force = Vector3.zero;
        Vector3 brake = Vector3.zero;
        var neighbor = getNeighborAhead();
        

        if (neighbor != null)
        {
            //Velocity *= 0.3f;
            brake.x = -SteerForce.x * 0.8f;
            brake.z = -SteerForce.z * 0.8f;
            Vector3 v = Velocity;
            v *= -1;
            brake += v;

            if (Vector3.SqrMagnitude(transform.position - neighbor.transform.position) <
                MAX_QUEUE_RADIUS * MAX_QUEUE_RADIUS)
            {
                Velocity *= 0.3f;
            }

        }

        return brake;
    }
    
}
