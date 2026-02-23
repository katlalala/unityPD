using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCatchScript : MonoBehaviour
{
    public float sizeIncrease = 0.2f;
    public float sizeDecrease = 0.2f;
    public float massIncrease = 0.5f;

    public TMP_Text eatenCounterText;
    public TMP_Text HPCount;

    private int eatenDonuts = 0;
    private int Health = 3;
    private Rigidbody2D rb;
    private SFX_Script sfx;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        rb.gravityScale = 4f; 

        if (HPCount != null) HPCount.text = "HP: " + Health;
        if (eatenCounterText != null) eatenCounterText.text = "Score: 0";
        
        Time.timeScale = 1;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.CompareTag("Donut"))
    {

        PlaySafeSFX(0); 
        eatenDonuts += 1;
        Grow(sizeIncrease, massIncrease);
        UpdateUI();
        Destroy(collision.gameObject);
    }
    else if(collision.CompareTag("Special"))
    {

        PlaySafeSFX(1); 
        eatenDonuts += 2;
        Grow(sizeIncrease * 2, massIncrease * 2);
        UpdateUI();
        Destroy(collision.gameObject);
    }
    else if (collision.CompareTag("Bad"))
    {

        PlaySafeSFX(2); 
        Health--;
        Shrink(sizeDecrease, 0.2f);
        UpdateUI();
        Destroy(collision.gameObject);

        if (Health <= 0) GameOver();
    }
}

    void Grow(float s, float m)
    {

        transform.localScale += new Vector3(s, s, 0);
        rb.mass += m;

        transform.position += new Vector3(0, 0.05f, 0);
    }

    void Shrink(float s, float m)
    {
        if (transform.localScale.x > 0.5f)
        {
            transform.localScale -= new Vector3(s, s, 0);
            rb.mass -= m;
        }
    }

    void UpdateUI()
    {
        if (HPCount != null) HPCount.text = "HP: " + Health;
        if (eatenCounterText != null) eatenCounterText.text = "Score: " + eatenDonuts;
    }

    void PlaySafeSFX(int index)
    {
        if (sfx != null) sfx.PlaySFX(index);
    }

    void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }
}