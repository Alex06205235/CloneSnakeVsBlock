using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skripts.Loss_Menu
{
    public class RestartGame : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
