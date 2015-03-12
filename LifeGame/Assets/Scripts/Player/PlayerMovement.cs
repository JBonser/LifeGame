using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;
	public float turnSpeed = 6.0f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;
	int wallMask;
	bool isJumping = false;
	float camRayLength = 100.0f;

	void Awake()
	{
		wallMask = LayerMask.GetMask ("WallMask");
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		bool jump = Input.GetButtonDown ("Jump");

		Move (h, v);

		Turning ();

		Animating (h, v);

	}

	void Move( float h, float v )
	{

		movement.Set (h, 0.0f, 0.0f);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit wallHit;

		if (Physics.Raycast (camRay, out wallHit, camRayLength, wallMask))
		{
			Vector3 playerToMouse = wallHit.point - transform.position;

			playerToMouse.z = 0.0f;
			playerToMouse.y = 0.0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			newRotation = Quaternion.RotateTowards( playerRigidBody.rotation, newRotation, turnSpeed * Time.deltaTime );
			playerRigidBody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking",walking );
	}
}
