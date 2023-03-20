using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    private Rigidbody _snake;
    public GameObject game;
    public GameObject bodyPart;
    public float circleDiameter;
    BlockComponent _healthPoints;
    List<GameObject> _snakeCircles = new List<GameObject>();
    public GameObject loss;

    public AudioSource cotton;
    public AudioSource eatFood;
    public int SnakeCircles => _snakeCircles.Count;
    List<Vector3> _positions = new List<Vector3>();

    void Awake()
    {
        _positions.Add(bodyPart.transform.position);

    }
    void Update()
    {
        float distance = (bodyPart.transform.position - _positions[0]).magnitude;

        if (distance > circleDiameter)
        {
            Vector3 direction = (bodyPart.transform.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + direction * circleDiameter);
            _positions.RemoveAt(_positions.Count - 1);

            distance -= circleDiameter;
        }

        for (int i = 0; i < _snakeCircles.Count; i++)
        {
            _snakeCircles[i].transform.position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / circleDiameter);
        }

    }

    public void AddCircle()
    {
        if (_positions.Count < 1)
            _positions.Add(bodyPart.transform.position);
        GameObject circle = Instantiate(bodyPart, _positions[^1], Quaternion.identity, transform);
        _snakeCircles.Add(circle);
        _positions.Add(circle.transform.position);
        // eatFood.Play();
    }
    
    public void RemoveCircle()
    {
        if (_snakeCircles.Count >= 1)
        {
            GameObject circle = _snakeCircles[^1];
            _snakeCircles.RemoveAt(_snakeCircles.Count - 1);
            // cotton.Play();
            Destroy(circle);
        }
        else if(_snakeCircles.Count == 0)
        {
            loss.SetActive(true);
            Destroy(bodyPart);
            game.SetActive(false);
        }
    }
}
