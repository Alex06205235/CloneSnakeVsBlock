using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Skripts.Snake
{
    public class HealthPoint : MonoBehaviour
    {
        private SnakeTail _snakeTail;
        [FormerlySerializedAs("Snake")]
        public global::Snake snake;
        [FormerlySerializedAs("HealthPointText")]
        [SerializeField] TextMeshProUGUI healthPointText;

        private void Start()
        {
            _snakeTail = snake.GetComponent<SnakeTail>();
            Random random = new Random();

            healthPointText.SetText(_snakeTail.SnakeCircles.ToString());

        }
        public void Update()
        {
            healthPointText.SetText(_snakeTail.SnakeCircles.ToString());
        }
    }
}
