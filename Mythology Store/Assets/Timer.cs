using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeLeft = 300;
    [SerializeField] public bool gamePaused = false;
    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {
        if (countdownText == null)
        {
            countdownText = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        gamePaused = GameManager.Instance.gamePaused;
        if (timeLeft == 0) return;
        if (!gamePaused)
        {

            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 0;
                GameManager.Instance.TimeFinished();
            }

            countdownText.text = FloatToTime(timeLeft);
        }
    }

    string FloatToTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);

        float seconds = Mathf.FloorToInt(time % 60);

        string timeFormat = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeFormat;
    }

}
