using UnityEngine;
using System.Collections;

public class ApplyForceAtOffet : MonoBehaviour {

	public float force = 200.0f;
	public Vector3 forceDirection = Vector3.up;
	public string buttonName = "Fire1";
	
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Input.GetButton(buttonName))
		{
			GetComponent<Rigidbody>().AddTorque(forceDirection.normalized*force, ForceMode.Acceleration);
            
		}
		else
		{
			GetComponent<Rigidbody>().AddTorque(forceDirection.normalized*-force,ForceMode.Acceleration);
		}
	}
}
