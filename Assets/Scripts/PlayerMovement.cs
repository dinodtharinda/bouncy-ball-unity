using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float maxX = 7.5f;

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private bool isDragging = false;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchStartPos.z = 0f;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            touchEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchEndPos.z = 0f;

            float slideLength = touchEndPos.x - touchStartPos.x;

            // Adjust the paddle position based on the slide length
            transform.position = new Vector3(transform.position.x + (slideLength *speed), transform.position.y, transform.position.z);

            // Update the start position for the next frame
            touchStartPos = touchEndPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }



}
