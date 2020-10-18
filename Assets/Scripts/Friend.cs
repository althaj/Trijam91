using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public int value;
    void Start()
    {
        value = Random.Range(0, 9);
        GetComponentInChildren<TextMeshProUGUI>().text = value.ToString();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
    }
}
