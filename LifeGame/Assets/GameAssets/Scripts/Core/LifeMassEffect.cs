using UnityEngine;
using System.Collections;

public class LifeMassEffect : MonoBehaviour {
	
	private LifeComponent lifeComp;
	private const float GRAVITY = -9.8f;

	Rigidbody objectRigidBody = null;
	// Use this for initialization
	void Awake () 
	{
		/*GameObject player = GameObject.Find ("Player");
		if( player )
			lifeComp = player.GetComponent<LifeComponent> ();*/
		lifeComp = GetComponent<LifeComponent> ();
		objectRigidBody = GetComponent<Rigidbody> ();
		objectRigidBody.WakeUp ();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		float LifeRange = lifeComp.maxLife - lifeComp.minLife;
		float force = ( lifeComp.maxLife - lifeComp.GetCurrentLife() ) / LifeRange;
		float forceVal = force * GRAVITY;
		objectRigidBody.AddForce( Vector3.up * forceVal, ForceMode.Acceleration );
	}
}
