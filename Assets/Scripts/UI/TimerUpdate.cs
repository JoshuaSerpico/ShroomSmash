using System.Collections;
using TMPro;
using UnityEngine;

public class TimerUpdate : MonoBehaviour
{
    public TMP_Text timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(startTimer());
    }

    IEnumerator startTimer() 
    {
        while (true)
        {
            float time = Time.time;

            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
