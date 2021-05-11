using UnityEngine;
using TMPro;

public class TutorialInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoObject;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private string[] tutorialMessages;
    [SerializeField] private bool[] paused;

    private short msgCount = 0;
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void NextMessage()
    {
        if(msgCount > tutorialMessages.Length)
        {
            Debug.LogError("No tutorial message for the index specified!");
            return;
        }

        info.text = tutorialMessages[msgCount];

        if(paused[msgCount])
        {
            Time.timeScale = 0f;
            infoObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            infoObject.SetActive(false);
        }

        msgCount++;
    }
}
