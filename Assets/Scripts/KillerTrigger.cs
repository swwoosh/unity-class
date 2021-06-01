using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillerTrigger : MonoBehaviour
{
	public GameObject Splash;


	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if (col.gameObject.tag == "Player")
		{

			// ... instantiate the splash where the player falls in.
			Instantiate(Splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			Destroy(col.gameObject);
		}
        else
        {
			Instantiate(Splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			Destroy(col.gameObject);
		}
	}

}
