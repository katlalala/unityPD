using TMPro;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    SFX_Script sfx;
    public TMP_Text counterText;
    private int destroyedObjects = 0;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            Destroy(collision.gameObject);
            destroyedObjects++;
            sfx.PlaySFX(0);
            counterText.text = "Objects Destroyed: " + destroyedObjects;
        }

        if (collision.CompareTag("Special"))
        {
            Destroy(collision.gameObject);
            destroyedObjects++;
            sfx.PlaySFX(1);
            counterText.text = "Objects Destroyed: " + destroyedObjects;
        }

        if (collision.CompareTag("Bad"))
        {
            Destroy(collision.gameObject);
            destroyedObjects++;
            sfx.PlaySFX(2);
            counterText.text = "Objects Destroyed: " + destroyedObjects;
        }
    }

}
