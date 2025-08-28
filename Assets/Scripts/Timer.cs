using TMPro;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float levelTime;
    public bool levelFinished = false;

    void Update()
    {
        if (!levelFinished)
        {
        levelTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(levelTime / 60);
        int seconds = Mathf.FloorToInt(levelTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
