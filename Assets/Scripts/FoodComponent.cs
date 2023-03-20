using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class FoodComponent : MonoBehaviour
{
    public int healthPoints;
    public TextMeshProUGUI healthPointsText;
    

    void Start()
    {
        healthPoints = Random.Range(1, healthPoints);
        healthPointsText.text = healthPoints.ToString();
    }
    

    private void OnCollisionEnter(Collision foodCollision)
    {
        if (!foodCollision.gameObject.CompareTag("Snake")) return;
        SnakeTail tail = foodCollision.transform.GetComponent<SnakeTail>();
        for (int x = 0; x < healthPoints; x++)
        {
            tail.AddCircle();
        }
        Destroy(gameObject);
        
    }
}
