using UnityEngine;

public class DynamicPlatform : MonoBehaviour
{
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.hidePlatforms)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }
    }
}
