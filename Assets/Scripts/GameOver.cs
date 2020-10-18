using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = $"Score: {PlayerPrefs.GetInt("Score").ToString()}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
