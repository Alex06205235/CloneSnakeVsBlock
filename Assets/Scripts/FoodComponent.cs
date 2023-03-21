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

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Snake")) return;
        SnakeTail tail = collider.transform.GetComponent<SnakeTail>();
        for (int x = 0; x < healthPoints; x++)
        {
            tail.AddCircle();
        }
        Destroy(gameObject);
    }
}
