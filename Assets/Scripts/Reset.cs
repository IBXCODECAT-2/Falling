using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private GameObject load;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            load.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
