using TMPro;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private FreezeFrame freezeFrame;
    public float levelTime;
    public bool levelFinished = false;
    public float freezeTime = 1f;

    void Update()
    {
        if (!levelFinished && !freezeFrame.isFreeze)
        {
        levelTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(levelTime / 60);
        int seconds = Mathf.FloorToInt(levelTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if(!levelFinished && freezeFrame.isFreeze)
        {
            levelTime += Time.deltaTime * freezeTime;

            int minutes = Mathf.FloorToInt(levelTime / 60);
            int seconds = Mathf.FloorToInt(levelTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
