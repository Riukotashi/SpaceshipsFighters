using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode down;
    public KeyCode up;
    public KeyCode ShotKey;
    public HealthBar healthBar;
    public GameObject bullet;
    private int currentHealth;
    private int maxHealth = 100;
    private float speedMovement = 5;
    private bool canShoot = true;
    private float shotDelay = 0.5F;
    private GameObject ShotPosition;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ShotPosition = transform.Find("ShotPosition").gameObject;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(Input.GetKey(left))
        {
            rb.velocity = new Vector2(-speedMovement, rb.velocity.y);
        }
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speedMovement, rb.velocity.y);
        }
        if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speedMovement);
        }
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, speedMovement);
        }

        if (Input.GetKey(ShotKey) && canShoot == true)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, ShotPosition.transform.position, bullet.transform.rotation);
        canShoot = false;
        StartCoroutine(ShootDelay());
    }

    private void Die()
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

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }
}
