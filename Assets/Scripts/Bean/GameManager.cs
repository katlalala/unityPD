using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public DonutSpawner spawner; 
    public GameObject startButton;
    public TextMeshProUGUI timerText;

    private float _time = 0f;
    private bool _isPlaying = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (_isPlaying)
        {
            _time += Time.deltaTime;
            int min = Mathf.FloorToInt(_time / 60);
            int sec = Mathf.FloorToInt(_time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
    }

    public void StartGame()
    {
        _isPlaying = true;
        if (startButton != null) startButton.SetActive(false); 
        if (spawner != null) spawner.ToggleBaking(true);
    }
}