using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;

    private Transform playerTran;
	private void Awake()
	{
		// Setting up the reference.
		playerTran = GameObject.FindGameObjectWithTag("Player").transform;
	}


	private bool NeedMoveX()
	{
		bool bMove = false;
		if (Mathf.Abs(transform.position.x - playerTran.position.x) > maxDistanceX)
			bMove = true;
		else
			bMove = false;
		return bMove;
	}
	private bool NeedMoveY()
	{
		bool bMove = false;
		if (Mathf.Abs(transform.position.y - playerTran.position.y) > maxDistanceY)
			bMove = true;
		else
			bMove = false;
		return bMove;
	}


	void FixedUpdate()
	{
		TrackPlayer();
	}


	void TrackPlayer()
	{
		float newX = transform.position.x;
		float newY = transform.position.y;

		if (NeedMoveX())
			newX= Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);

		if (NeedMoveY())
			newY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);
		 
		transform.position = new Vector3(newX, newY, transform.position.z);
	}
	

    // Update is called once per frame
    void Update()
    {
        
    }
}
