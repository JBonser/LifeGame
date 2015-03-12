using UnityEngine;
using System.Collections;

public class LifeComponent : MonoBehaviour {

	public float initialLife;
	public float minLife;
	public float maxLife;


	private float currentLife;
	// Use this for initialization
	void Start () {
		currentLife = initialLife;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetCurrentLife()
	{
		return currentLife;
	}

	public void TransferLife( float lifeAmount )
	{
		currentLife += lifeAmount;
	}
}
