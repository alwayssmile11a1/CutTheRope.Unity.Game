using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkJoint : MonoBehaviour {


    public int jointCount = 7;
    public GameObject joint;
    public GameObject hook;

	// Use this for initialization
	void Start () {

        LinkJoints();

	}
	
    private void LinkJoints()
    {
        Rigidbody2D previousJoint = hook.GetComponent<Rigidbody2D>();

        for(int i = 0; i<jointCount;i++)
        {
            GameObject gameObject = Instantiate(joint, transform);

            gameObject.GetComponent<HingeJoint2D>().connectedBody = previousJoint;

            previousJoint = gameObject.GetComponent<Rigidbody2D>();


            if(i==jointCount-1)
            {
                LinkWeight(previousJoint);
            }

        }
    }

    private void LinkWeight(Rigidbody2D body2D)
    {
        GameObject weight = GameObject.Find("Weight");
        HingeJoint2D hingeJoint2D = weight.AddComponent<HingeJoint2D>();
        hingeJoint2D.connectedBody = body2D;
        hingeJoint2D.autoConfigureConnectedAnchor = false;
        hingeJoint2D.anchor = Vector2.zero;
        hingeJoint2D.connectedAnchor = new Vector2(0, -0.6f);
    }

	
}
