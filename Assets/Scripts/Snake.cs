using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Snake : MonoBehaviour
{
    SnakeTail _snakeTail;
    
    int SnakeHealth
    {
        get
        {
            return _snakeTail.SnakeCircles;
        }
    }

    public int snakeLength = 4;

    public TextMeshProUGUI snakeHealthPointText;
    
    void Awake()
    {
        _snakeTail = GetComponent<SnakeTail>();
        for (int i = 1; i < snakeLength; i++) _snakeTail.AddCircle();
        snakeHealthPointText.SetText(SnakeHealth.ToString());
    }

    void Update()
    {
        snakeHealthPointText.SetText((SnakeHealth + 1).ToString());
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Food")) return;
        FoodComponent count = other.transform.GetComponent<FoodComponent>();
        for (int i = 0; i < count.healthPoints; i++)
        {
            _snakeTail.AddCircle();
        }
        Destroy(other.gameObject);
    }
}
