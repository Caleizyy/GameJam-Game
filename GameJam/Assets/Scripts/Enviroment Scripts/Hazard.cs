using UnityEngine;

public class Hazard : MonoBehaviour
{
    SpriteRenderer sprite;
    private bool isHidden = true;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
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
