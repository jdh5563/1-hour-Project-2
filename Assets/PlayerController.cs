using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasJumped;
    public GameObject mouseLeft;
    public GameObject mouseRight;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasJumped)
        {
            if (Input.GetMouseButtonDown(0) && gameObject.name == "Player 2")
            {
                rb.velocity = new Vector2(0, 12.5f);
                hasJumped = true;
            }

            if (Input.GetMouseButtonDown(1) && gameObject.name == "Player 1")
            {
                rb.velocity = new Vector2(0, 12.5f);
                hasJumped = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            mouseLeft.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseLeft.GetComponent<SpriteRenderer>().color = Color.black;

            if (rb.velocity.y > 7 && gameObject.name == "Player 2")
            {
                rb.velocity = new Vector2(0, 7f);
            }
        }

        if (Input.GetMouseButton(1))
        {
            mouseRight.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            mouseRight.GetComponent<SpriteRenderer>().color = Color.black;

            if (rb.velocity.y > 7 && gameObject.name == "Player 1")
            {
                rb.velocity = new Vector2(0, 7f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasJumped = false;

        if(collision.collider.tag == "Obstacle")
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
    }
}
