using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject[] pickups;
    public float pickuptime = 5f;
    public float leftX = 12f;
    public float rightX = -12f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPickup());
    }

    IEnumerator spawnPickup()
    {
        yield return new WaitForSeconds(pickuptime);

        float randomx = Random.Range(leftX, rightX);
        Vector3 randomPos = new Vector3(randomx, 15, 0);
        int index = Random.Range(0, pickups.Length);
        Instantiate(pickups[index], randomPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
