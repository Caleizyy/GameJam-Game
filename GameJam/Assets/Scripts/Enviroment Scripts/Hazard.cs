using UnityEngine;

public class Hazard : MonoBehaviour
{
    SpriteRenderer sprite;
    private bool isHidden = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.hideHazards && isHidden)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHidden = false;
            GameManager.PauseEverything();
        }
    }
}
