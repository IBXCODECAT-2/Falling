using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class TutorialInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoObject;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private Button continueButton;
    [SerializeField] private string[] tutorialMessages;
    [SerializeField] private bool[] paused;
    [SerializeField] private float automatedContinueDelay;

    private short msgCount = 0;
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private IEnumerator Delay(short msg)
    {
        switch(msg)
        {
            case 2:
                yield return new WaitForSecondsRealtime(automatedContinueDelay);
                break;
            default:
                yield return new WaitForSecondsRealtime(automatedContinueDelay * 2);
                break;
        }

        NextMessage();
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
            continueButton.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            continueButton.enabled = false;
            StartCoroutine(Delay(msgCount));
        }

        msgCount++;
    }
}
