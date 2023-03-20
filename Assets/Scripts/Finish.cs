using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skripts.Control
{
    public class Finish : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Snake"))
            {
                LoadLevel();
            }
        }
        public void LoadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LevelIndex++;
        }
        const string LevelIndexKey = "GameLvlIndex";
        public static int LevelIndex
        {
            get => PlayerPrefs.GetInt(LevelIndexKey, 0);
            set {
                PlayerPrefs.SetInt(LevelIndexKey, value);
                PlayerPrefs.Save();
            }
        }
    }
}
