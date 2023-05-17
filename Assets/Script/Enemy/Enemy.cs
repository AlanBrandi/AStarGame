using System;
using System.Collections.Generic;
using UnityEngine;

namespace QPathFinder
{
    public class Enemy : MonoBehaviour, IObserver
    {
        [SerializeField] int targetNode;
        [SerializeField] EnemyStats enemyStats;
        public bool autoRotateTowardsDestination = true;
        public float playerFloatOffset;     // This is how high the player floats above the ground. 
        public float raycastOriginOffset;   // This is how high above the player u want to raycast to ground. 
        public int raycastDistanceFromOrigin = 40;   // This is how high above the player u want to raycast to ground. 
        public bool thoroughPathFinding = false;    // uses few extra steps in pathfinding to find accurate result. 
        public bool useGroundSnap = false;          // if snap to ground is not used, player goes only through nodes and doesnt project itself on the ground. 
        public List<Node> nodes;

        public QPathFinder.Logger.Level debugLogLevel;
        public float debugDrawLineDuration;

        void Awake()
        {
            QPathFinder.Logger.SetLoggingLevel(debugLogLevel);
            QPathFinder.Logger.SetDebugDrawLineDuration(debugDrawLineDuration);

        }
        private void Start()
        {
            if (PathFinder.instance == null && PathFinder.instance.graphData != null)
                return;
            {
                nodes = PathFinder.instance.graphData.nodes;
                MoveTo(nodes[targetNode]);
            }
            BridgeRaise.Instance.Attach(this.GetComponent<Enemy>());
        }
        public void NotifyBridgeRaise()
        {
            SeachForClosest();
        }
        void MoveTo(Node node)
        {
            {
                PathFinder.instance.FindShortestPathOfPoints(gameObject.transform.position, node.Position, PathFinder.instance.graphData.lineType,
                Execution.Synchronous,
                SearchMode.Intermediate,
                delegate (List<Vector3> points)
                {
                    PathFollowerUtility.StopFollowing(gameObject.transform);
                    if (useGroundSnap)
                    {
                        FollowThePathWithGroundSnap(points);
                    }
                    else
                        FollowThePathNormally(points);
                }
             );
            }
        }

        void FollowThePathWithGroundSnap(List<Vector3> nodes)
        {
            PathFollowerUtility.FollowPathWithGroundSnap(gameObject.transform,
                                                        nodes,
                                                        enemyStats.speed,
                                                        autoRotateTowardsDestination,
                                                        Vector3.down, playerFloatOffset, LayerMask.NameToLayer(PathFinder.instance.graphData.groundColliderLayerName),
                                                        raycastOriginOffset, raycastDistanceFromOrigin);
        }

        void FollowThePathNormally(List<Vector3> nodes)
        {
            PathFollowerUtility.FollowPath(gameObject.transform, nodes, enemyStats.speed, autoRotateTowardsDestination);
        }


        public void SeachForClosest()
        {
            MoveTo(nodes[targetNode]);
        }

    }
}
