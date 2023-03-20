using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSnake : MonoBehaviour
{
    public Transform snake;
    Vector3 deltaPos;
    void Start()
    {
        deltaPos = transform.position - snake.position;
    }

    void Update()
    {
        transform.position = snake.position + deltaPos;
    }
}
