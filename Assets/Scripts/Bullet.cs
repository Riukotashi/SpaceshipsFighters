
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dir;
    Rigidbody2D rb;
    int damage = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(15 * dir, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
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
