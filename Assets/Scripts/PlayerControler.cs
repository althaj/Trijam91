using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float power = 5f;
    [SerializeField] private float reloadTime = 0.2f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject pickup;

    private int score = 0;

    private float currentReloadTime;
    private Rigidbody2D rb;
    private Vector2 inputVector = Vector2.zero;

    private int health = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        currentReloadTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) && currentReloadTime <= 0)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = inputVector * power;
    }

    /// <summary>
    /// Shoot a bullet.
    /// </summary>
    private void Shoot()
    {
        currentReloadTime = reloadTime;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.AngleAxis(Mathf.Rad2Deg * angle - 90, Vector3.forward));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            LoseHealth();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Friend"))
        {
            AddScore(col.gameObject.GetComponent<Friend>().value);
            Instantiate(pickup, transform.position, transform.rotation);
            Destroy(col.gameObject);
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene(1);
    }

    public void LoseHealth()
    {
        health--;
        healthText.text = $"Health: {health.ToString()}";
        if (health <= 0)
            GameOver();
    }

    public void AddScore(int amt)
    {
        score += amt;
        scoreText.text = $"Score: {score.ToString()}";
    }
}
