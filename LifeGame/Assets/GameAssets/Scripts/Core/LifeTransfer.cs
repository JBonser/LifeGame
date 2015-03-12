using UnityEngine;
using System.Collections;

public class LifeTransfer : MonoBehaviour {

	public float initialLife;
	public float minLife;
	public float maxLife;

	private float currentLife;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TransferLifeTo( LifeTransfer other )
	{
		currentLife -= 0.1f;
		other.currentLife += 0.1f;
	}	
}
