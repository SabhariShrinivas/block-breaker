using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        canvas.enabled = true;
    }
}
