using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRope : MonoBehaviour
{
    [SerializeField] int Links;
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public Weight weight;
    public void Start()
    {
        GenerateRope();
    }
    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < Links;i++)
        {
            GameObject Link = Instantiate(linkPrefab,this.transform);
            HingeJoint2D joint = Link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            if (i < Links - 1) { 
            previousRB = Link.GetComponent<Rigidbody2D>();
            }
            else
            {
                weight.ConnectRopeEnd(Link.GetComponent<Rigidbody2D>());

            }


        }
    }
}
