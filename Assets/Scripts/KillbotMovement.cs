using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves the killbot [displacement] units to either side, back and forth.
/// </summary>
public class KillbotMovement : MonoBehaviour
{
    // how far to either side the killbot can move
    public float displacement = 10;
    public float speed = 1;

    private Boolean isMovingLeft = true;

    private float minX;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        float startPosition = gameObject.transform.position.x;
        minX = startPosition - displacement;
        maxX = startPosition + displacement;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= minX) { 
            isMovingLeft = false;
        }

        if (gameObject.transform.position.x >= maxX)
        {
            isMovingLeft = true;
        }

        if (isMovingLeft)
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        } 
        else
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
