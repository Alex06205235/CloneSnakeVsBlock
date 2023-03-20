using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skripts.Loss_Menu
{
    public class Loadcenes : MonoBehaviour

    {  public void LoadSceneOne()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSceneZero()
        {
            SceneManager.LoadScene(0);
        }

    }
}
