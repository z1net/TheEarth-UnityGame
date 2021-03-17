using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneHelper : MonoBehaviour
{
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
