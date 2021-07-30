using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float Xmin = 0f;
    [SerializeField] float Xmax = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousepos = Input.mousePosition.x / Screen.width * 16; //aspect ratio is 16:9 where 16 is the width
        Vector2 pos = new Vector2(mousepos, transform.position.y);
        pos.x = Mathf.Clamp(mousepos, Xmin, Xmax);
        transform.position = pos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
