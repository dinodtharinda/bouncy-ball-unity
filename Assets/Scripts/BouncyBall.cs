using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Tilemaps;
public class BouncyBall : MonoBehaviour


{
    public float minY = -5.5f;
    Rigidbody2D rb;
    public float maxVelocity;

    public Tilemap tilemap;

    // int brickCount;
    int score = 0;


    void Start()
    {
        // brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;

        // tilemap = GameObject.FindObjectOfType<Tilemap>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector2.down * 10f;
        }


        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
        else
        {

            float increaseFactor = 1.1f;
            rb.velocity *= increaseFactor;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        angleBall(collision);
        if (collision.gameObject.CompareTag("Brick Tile"))
        {

            Vector3 hitPosition = collision.GetContact(0).point;


            Vector3Int cellPosition = tilemap.WorldToCell(hitPosition);


            if (tilemap.GetTile(cellPosition))
            {

                tilemap.SetTile(cellPosition, null);


                score += 10;
                // brickCount--;

                GetFilledCellCount();
            }
        }


        Debug.Log(collision.gameObject.name);
    }

    private void GetFilledCellCount()
    {
        int filledCellCount = 0;

        BoundsInt bounds = tilemap.cellBounds;

        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position))
            {
                filledCellCount++;
            }
        }

        Debug.Log("Filled Cell Count: " + filledCellCount);
    }

    bool angleStatus;
    float angle;
    void angleBall(Collision2D collion)
    {
        // Get the direction from the ball to the collision point
        Vector2 impactDirection = (collion.GetContact(0).point - (Vector2)transform.position).normalized;

        if (angleStatus)
        {
            angle = 5f;

        }
        else
        {
            angle = -5f;
        }
        angleStatus = !angleStatus;
        Vector2 newVelocity = Quaternion.Euler(0, 0, angle) * rb.velocity;

        // Apply the new velocity to the ballasdfasd
        rb.velocity = newVelocity; 
    }


}
