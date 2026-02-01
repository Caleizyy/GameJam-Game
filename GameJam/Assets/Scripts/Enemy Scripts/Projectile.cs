using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    private Rigidbody2D rb;
    private bool startScalling = false;
    private SpriteRenderer sprite;
    private float animationTimer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
        sprite = GetComponent<SpriteRenderer>();
        if (GameManager.hideEnemies)
        {
            sprite.enabled = false;
        }
    }
    void Update()
    {
        if (GameManager.hideEnemies)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }
        if (startScalling)
        {
            animationTimer += Time.unscaledDeltaTime;
            sprite.enabled = true;
            if (animationTimer > 0.5f && 1.5f > animationTimer)
            {
                transform.localScale += new Vector3(1f, 1f, 0f) * Time.unscaledDeltaTime;
            }
        }
        rb.linearVelocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" && !startScalling)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            startScalling = true;
            GameManager.PauseEverything();
        }
    }
}
