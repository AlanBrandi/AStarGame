﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace QPathFinder
{
    public class MoveToNode : MonoBehaviour
    {
        public GameObject playerObj;
        public float playerSpeed = 20.0f;
        public bool autoRotateTowardsDestination = true;
        public float playerFloatOffset;     // This is how high the player floats above the ground. 
        public float raycastOriginOffset;   // This is how high above the player u want to raycast to ground. 
        public int raycastDistanceFromOrigin = 40;   // This is how high above the player u want to raycast to ground. 
        public bool thoroughPathFinding = false;    // uses few extra steps in pathfinding to find accurate result. 

        public bool useGroundSnap = false;          // if snap to ground is not used, player goes only through nodes and doesnt project itself on the ground. 

        public QPathFinder.Logger.Level debugLogLevel;
        public float debugDrawLineDuration;

        void Awake()
        {
            QPathFinder.Logger.SetLoggingLevel( debugLogLevel );
            QPathFinder.Logger.SetDebugDrawLineDuration ( debugDrawLineDuration );
        }
        void OnGUI()
        {
            if ( PathFinder.instance == null && PathFinder.instance.graphData != null ) 
                return;
            {
                int y = 0;
                foreach ( var go in PathFinder.instance.graphData.nodes  )
                {
                    if ( GUI.Button ( new Rect ( Screen.width - 150, y*30, 150, 30), "Node:" + go.autoGeneratedID.ToString() ))
                    {
                        MoveTo( go );
                    }
                    y++;
                }
            }
        }

        void MoveTo( Node node )
        {
            {
                PathFinder.instance.FindShortestPathOfPoints( playerObj.transform.position, node.Position,  PathFinder.instance.graphData.lineType, 
                    Execution.Asynchronously,
                    SearchMode.Simple,
                    delegate ( List<Vector3> points ) 
                    { 
                        PathFollowerUtility.StopFollowing( playerObj.transform );
                        if ( useGroundSnap )
                        {
                           FollowThePathWithGroundSnap ( points );
                        }
                        else 
                            FollowThePathNormally ( points );
                    }
                 );
            }
        }

        void FollowThePathWithGroundSnap ( List<Vector3> nodes )
        {
            PathFollowerUtility.FollowPathWithGroundSnap ( playerObj.transform, 
                                                        nodes, 
                                                        playerSpeed, 
                                                        autoRotateTowardsDestination,
                                                        Vector3.down, playerFloatOffset, LayerMask.NameToLayer( PathFinder.instance.graphData.groundColliderLayerName ),
                                                        raycastOriginOffset, raycastDistanceFromOrigin );
        }

        void FollowThePathNormally ( List<Vector3> nodes )
        {
            PathFollowerUtility.FollowPath ( playerObj.transform, nodes, playerSpeed, autoRotateTowardsDestination );
        }
    }
}
