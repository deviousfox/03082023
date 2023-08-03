using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameAssets.Scripts
{
    public class Restart : MonoBehaviour
    {
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}