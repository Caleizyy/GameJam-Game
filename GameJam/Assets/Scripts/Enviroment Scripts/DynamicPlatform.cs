using UnityEngine;

public class DynamicPlatform : MonoBehaviour
{
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
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
