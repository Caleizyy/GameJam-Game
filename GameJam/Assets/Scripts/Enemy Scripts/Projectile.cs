using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 30f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        rb.linearVelocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.activeSelf)
            Destroy(gameObject);
    }
}
