using TMPro;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private FreezeFrame freezeFrame;
    [SerializeField] private PlayerController player;
    public float levelTime;
    public bool levelFinished = false;
    public float freezeTime = 1f;
    private float timeScale;

    void Update()
    {
        if (!levelFinished)
        {
            if(freezeFrame.isFreeze || player.isRewinding)
            {
                timeScale = freezeTime;
            }
            else
            {
                timeScale = 1f;
            }
            levelTime += Time.deltaTime * timeScale;

            int minutes = Mathf.FloorToInt(levelTime / 60);
            int seconds = Mathf.FloorToInt(levelTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }


    }
}
