using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimerCountDown : MonoBehaviour
{
    [SerializeField] private float startValue; 
    [SerializeField] private bool countDown; 
    [SerializeField] private bool countOnStart;
    [SerializeField] TextMeshProUGUI timerText;

    private float currentTime;
    private bool active = false;

    [SerializeField] private UnityEvent onTimerFinished = new();

    private void Start()
    {
        if (countOnStart)
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (!active) return;
        if (countDown)
        {
            currentTime -= Time.deltaTime;
            if(timerText != null) timerText.text = ((int)currentTime).ToString() + " seconds left";
            if (currentTime <= 0)
            {
                currentTime = 0;
                active = false;
                onTimerFinished.Invoke();
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (timerText != null) timerText.text = ((int)currentTime).ToString() + " / " + countDown;
            if (currentTime >= startValue)
            {
                active = false;
                onTimerFinished.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        active = true;
        currentTime = countDown ? startValue : 0;
    }

    public void StopTimer() => active = false;

    public void ResetTimer() => currentTime = countDown ? startValue : 0;
}
