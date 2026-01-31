using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    private float smoothSpeed = 5f;
    private Vector3 offset = new Vector3(0, 2, -20);
    public Vector2 minBounds;
    public Vector2 maxBounds;
    private float zoomSpeed = 0.4f; 
    private float targetZoom = 2f;
    private float zoomTimer = 0f;

    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = Mathf.Clamp(targetPos.x, minBounds.x, maxBounds.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minBounds.y, maxBounds.y);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.unscaledDeltaTime);
        if (GameManager.IsGamePaused)
        {
            zoomTimer += Time.unscaledDeltaTime;
            if (zoomTimer >= 0.5f && zoomTimer < 1.5f)
            {
                Camera.main.orthographicSize = Mathf.Lerp(
                Camera.main.orthographicSize,
                targetZoom,
                Time.unscaledDeltaTime * zoomSpeed
                );
            }
        }
    }
    private void Start()
    {
        transform.position = player.position + offset;
    }
}
