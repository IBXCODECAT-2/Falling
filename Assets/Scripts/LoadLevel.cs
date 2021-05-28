using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene(1);
    }
}
