using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 15.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }


    public void GoToUsine()
    {
        g.AStar(currentNode, wps[9]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, wps[7]);
        currentWP = 0;
    }

    void LateUpdate()
    {
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
            return;

        currentNode = g.getPathPoint(currentWP);
        if (Vector3.Distance(
            g.getPathPoint(currentWP).transform.position,
            transform.position) < accuracy)
        {
            currentWP++;
        }

        if (currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                this.transform.position.y,
                goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);

            transform.position = Vector3.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
        }
    }
}