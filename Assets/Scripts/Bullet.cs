using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float power = 5f;
    [SerializeField] private GameObject explosion;

    private Rigidbody2D rb;

    public float Power { get => power; set => power = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * Power;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<PlayerControler>().AddScore(5);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Friend"))
        {
            PlayerControler player = FindObjectOfType<PlayerControler>();
            player.AddScore(-col.gameObject.GetComponent<Friend>().value);
            player.LoseHealth();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}
