using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingClouds : MonoBehaviour
{
    public float speedCloud = 0.05f;
    private Rigidbody2D rbCloud;
    private float sizeClouds;

    // Start is called before the first frame update
    private void Start()
    {
        rbCloud = GetComponent<Rigidbody2D>();
        rbCloud.velocity = new Vector2(GameControl.instance.scrollSpeed * speedCloud, 0.0f);
        sizeClouds = 7.5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameControl.instance.gameOver == true)
        {
            rbCloud.velocity = Vector2.zero;
        }
        if (transform.position.x < -7.5f)
        {
            RepositionCloud();
        }
    }

    private void RepositionCloud()
    {
        Vector2 cloudOffset = new Vector2(sizeClouds * 2.0f, 0.0f);
        transform.position = (Vector2)transform.position + cloudOffset;
    }
}