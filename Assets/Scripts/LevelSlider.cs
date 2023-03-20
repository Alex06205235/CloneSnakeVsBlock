using UnityEngine;
using UnityEngine.UI;

namespace Skripts.Score
{
    public class LevelSlider : MonoBehaviour
    {
        public SnakeTail player;
        public Transform finishPlatform;
        public Slider slider;

        private float _startZ;
        private float _minimumReachedY;
    
        private void Start()
        {
            _startZ = player.transform.position.z;
        }


        private void Update()
        {
            _startZ = Mathf.Min(_minimumReachedY, Mathf.Abs(player.transform.position.z));
            var currentPlayerPosition = player.transform.position.z;
            var t = Mathf.InverseLerp(_startZ, finishPlatform.position.z, currentPlayerPosition);
            slider.value = t;
        }
    }
}
