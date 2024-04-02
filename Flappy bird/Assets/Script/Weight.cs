using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] float distanceConnect;
    public void ConnectRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D Joint = gameObject.AddComponent<HingeJoint2D>();
        Joint.autoConfigureConnectedAnchor= false;
        Joint.connectedBody= endRB;
        Joint.anchor = Vector2.zero;
        Joint.connectedAnchor = new Vector2(0,-distanceConnect);


    }
}
