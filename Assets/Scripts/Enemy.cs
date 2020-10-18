using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = ((char)Random.Range(65, 91)).ToString();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
    }
}
