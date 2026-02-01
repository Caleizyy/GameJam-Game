using System;
using UnityEngine;
using UnityEngine.U2D;

public class MaskEvents : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mask2")
        {
            FindFirstObjectByType<PopupManager>().ShowPopup("Press K to switch to the second mask, you can now change between them, this one reveals hazards");
            GameManager.hasMask2 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Mask1")
        {
            FindFirstObjectByType<PopupManager>().ShowPopup("Press J to put on the third mask, it reveals projectiles");
            GameManager.hasMask1 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Mask3")
        {
            FindFirstObjectByType<PopupManager>().ShowPopup("Press L to put on the mask, it reveals platforms");
            GameManager.hasMask3 = true;
            Destroy(collision.gameObject);
        }
    }
}
