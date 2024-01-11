using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
   
    void Start()
    {
        ResizeSquare();
    }

    void ResizeSquare()
    {
        // Get the screen width and height
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Calculate 10% of the screen size
        float squareSize = screenWidth * 0.002f;

        // Set the size of the square
        transform.localScale = new Vector3(squareSize, squareSize, transform.position.z);
    }
}
