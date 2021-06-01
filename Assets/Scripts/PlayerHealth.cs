using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float healthpoint = 20f;
    float health = 100f;
    SpriteRenderer healthbar;
    Vector3 healthbarScale;
    public float damageRepeat = 0.5f;
    public float hurtForce = 5f;
    private float lastHurt;
    private Animator anim;
    public AudioClip[] ouchClips;
    //Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.Find("Health_0").GetComponent<SpriteRenderer>();
        healthbarScale = healthbar.transform.localScale;
        lastHurt = Time.time;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time > damageRepeat + lastHurt )
            {
                if (health > 0)
                {
                    takeDamage(collision.gameObject.transform);
                    lastHurt = Time.time;

                    if (health <= 0)
                    {
                        anim.SetTrigger("die");
                        Collider2D[] colliders = GetComponents<Collider2D>();
                        foreach (Collider2D c in colliders)
                            c.isTrigger = true;


                        SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
                        foreach (SpriteRenderer s in sp)

                            s.sortingLayerName = "UI";

                        GetComponentInChildren<Gun>().enabled = false;
                        GetComponent<PlayerControl>().enabled = false;


                    }
                }
            }
        }

    }
    void takeDamage(Transform enemy)
    {
        health -= healthpoint;
        UpdateHealthBar();

        Vector3 hurtVector = transform.position - enemy.position + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }
    void UpdateHealthBar()
    {
        healthbar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthbar.transform.localScale = new Vector3(health * 0.02f, 2, 1);
    }
    void Update()
    {

    }
}
