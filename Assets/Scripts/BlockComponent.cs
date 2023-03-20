using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class BlockComponent : MonoBehaviour
{
        public int maxHealthPoints;
        bool _canTakeDamage;
        int _healthPoints;
        public TextMeshProUGUI healthPointsText;

        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                if (value > maxHealthPoints)
                {
                    _healthPoints = maxHealthPoints;
                }
                else
                {
                    _healthPoints = value;
                }
            }
        }
        public float damagePeriodic;
        SnakeTail _snakeTail;
        ScoresComponent _scoresComponent;
        void Start()
        {
            _scoresComponent = FindObjectOfType<ScoresComponent>();
            _snakeTail = FindObjectOfType<SnakeTail>();
            GameObject[] chunks = GameObject.FindGameObjectsWithTag("SpawnChunk");
            if (chunks.Length > 1)
            {
                FoodComponent[] foods = chunks[chunks.Length - 2].GetComponentsInChildren<FoodComponent>();
                HealthPoints = Random.Range(_snakeTail.SnakeCircles - 1, _snakeTail.SnakeCircles + foods.Sum(food => food.healthPoints));
            }
            else
            {
                HealthPoints = Random.Range(1, _snakeTail.SnakeCircles);
            }
            // HealthPoints = Random.Range(1, _snakeTail.SnakeCircles + foods.Sum(food => food.healthPoints));
            healthPointsText.text = HealthPoints.ToString();
            GetComponent<Renderer>().material.color = GetColor(HealthPoints);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Snake")) return;
            _canTakeDamage = true;
            _snakeTail = collision.gameObject.GetComponent<SnakeTail>();
            StartCoroutine(TakeWorldDamage());
        }

        void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Snake")) return;
            _canTakeDamage = false;
        }

        IEnumerator TakeWorldDamage()
        {
            while (_canTakeDamage) {
                if (HealthPoints == 0 || _snakeTail.SnakeCircles == 0)
                {
                    _canTakeDamage = false;
                }
                _snakeTail.RemoveCircle();
                HealthPoints--;
                healthPointsText.text = HealthPoints.ToString();
                _scoresComponent.Current++;
                yield return new WaitForSeconds(damagePeriodic);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (HealthPoints == 0)
            {
                Destroy(gameObject);
            }
        }

        Color GetColor(int hp)
        {
            return Color.Lerp(Color.red, Color.blue, (float)hp / maxHealthPoints);
        }
    }