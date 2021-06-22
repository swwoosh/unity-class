using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	public GameObject[] pickups;				// Array of pickup prefabs with the bomb pickup first and health second.
	public float pickupDeliveryTime = 5f;		// Delay on delivery.
	public float dropRangeLeft;					// Smallest value of x in world coordinates the delivery can happen at.
	public float dropRangeRight;				// Largest value of x in world coordinates the delivery can happen at.
	public float highHealthThreshold = 60f;		// The health of the player, above which only bomb crates will be delivered.
	public float lowHealthThreshold = 40f;		// The health of the player, below which only health crates will be delivered.


	private PlayerHealth playerHealth;			// Reference to the PlayerHealth script.


	void Awake ()
	{
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}


	void Start ()
	{
		StartCoroutine(DeliverPickup());

	}


	public IEnumerator DeliverPickup()
	{
		yield return new WaitForSeconds(pickupDeliveryTime);

		float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);

		Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);

		if (playerHealth.health >= highHealthThreshold)
		{
			Instantiate(pickups[0], dropPos, Quaternion.identity);
		}
		else if (playerHealth.health <= lowHealthThreshold)
		{
			Instantiate(pickups[1], dropPos, Quaternion.identity);
		}
		else
		{
			int pickupIndex = Random.Range(0, pickups.Length);
			Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
		}
	}
}
