using UnityEngine;
using System.Collections;

public class DrTrial1 : MonoBehaviour 
{
	private Vector3 direction;
	private float moveRemainingTime;
	public float moveSpeed = 5.0f;
	private Vector3 moveVector;
	
	// Use this for initialization
	void Start () 
	{
		moveRemainingTime = 0;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if(Physics.Raycast(ray, out raycastHit))
			{
				Debug.Log(raycastHit.point);
				MoveTo(raycastHit.point);
			}
			
		}
		
		//Handle Player movement
		if(moveRemainingTime > 0)
		{
			//moveVector = direction.normalized * moveSpeed;
			transform.position = transform.position + moveVector*Time.deltaTime;
			moveRemainingTime -= Time.deltaTime;
	
		}
	}
	
	void MoveTo(Vector3 target)
	{
		target.y = transform.position.y;
		transform.LookAt(target);
		direction = target - transform.position;
		moveVector = direction.normalized * moveSpeed; //How much to move per second
		moveRemainingTime = direction.magnitude/moveVector.magnitude;
	}
}