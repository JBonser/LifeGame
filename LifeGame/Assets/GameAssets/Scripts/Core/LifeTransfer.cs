using UnityEngine;
using System.Collections;

public class LifeTransfer : MonoBehaviour {

	public float lifeTransferAmount = 3f;

	private LifeComponent lifeComponent;
	float camRayLength = 100.0f;

	// Use this for initialization
	void Start () {
		lifeComponent = GetComponent<LifeComponent> ();
	}
	
	// Update is called once per frame
	void Update () {

		GameObject ObjectInSight = PlayerAim ();
		if (ObjectInSight) {
			LifeComponent objectLife = ObjectInSight.GetComponent<LifeComponent>();

			if(objectLife)
			{
				if (Input.GetMouseButton (0))
				{
					TransferLife(objectLife, lifeTransferAmount);
				}
				if (Input.GetMouseButton (1))
				{
					TransferLife(objectLife, -lifeTransferAmount);
				}
			}
		}
	}

	GameObject PlayerAim()
	{
		int wallMask = LayerMask.GetMask ("WallMask");
		
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		RaycastHit wallHit;
		
		if (Physics.Raycast (camRay, out wallHit, camRayLength, wallMask))
		{
			Vector3 playerToMouse = wallHit.point - transform.position;
			
			playerToMouse.z = 0.0f;

			playerToMouse.Normalize();

			Ray playerAimRay = new Ray( transform.position, playerToMouse );

			RaycastHit objectHit;

			if( Physics.Raycast( playerAimRay, out objectHit, camRayLength ) )
			{
				return objectHit.transform.gameObject;
			}
		}
		return null;
	}

	void TransferLife( LifeComponent other, float transferAmount )
	{
		if ( ( lifeComponent.GetCurrentLife () < lifeComponent.maxLife || transferAmount < 0f ) &&
		     ( other.GetCurrentLife () > other.minLife || transferAmount < 0f ) ) 
		{
			lifeComponent.TransferLife (transferAmount);
			other.TransferLife (-transferAmount);
		}
	}	
	

}
