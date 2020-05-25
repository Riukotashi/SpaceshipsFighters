using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    int delay = 0;
    GameObject a;
    public GameObject bullet;
    Rigidbody2D rb;
    public float speed;
    public KeyCode left;
    public KeyCode right;
    public KeyCode down;
    public KeyCode up;
    public KeyCode ShotKey;
    public HealthBar healthBar;
    public int maxHealth = 100;
    int currentHealth;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKey(left))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }

        if (Input.GetKey(ShotKey) && delay > 400)
        {
            Shoot();
        }

        delay++;
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(bullet, a.transform.position, bullet.transform.rotation);
    }
    
    void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
