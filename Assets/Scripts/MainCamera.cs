using UnityEngine;

public class MainCamera : MonoBehaviour
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
    
