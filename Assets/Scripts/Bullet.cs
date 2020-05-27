
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public  int dir;
    private Rigidbody2D rb;
    private int damage = 10;
    private int bulletSpeed = 15;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(bulletSpeed * dir, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SpaceShip>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
