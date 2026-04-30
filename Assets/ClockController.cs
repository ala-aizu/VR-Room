using System;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public Transform hoursHand, minutesHand,secondsHand;
    public Vector3 baseRotation;

    private float hoursToDegrees = 2f * Mathf.PI * Mathf.Rad2Deg / 12f;
    private float minutesToDegrees = 2f * Mathf.PI * Mathf.Rad2Deg / 60f;
    private float secondsToDegrees = 2f * Mathf.PI * Mathf.Rad2Deg / 60f;

    void Start()
    {
        if (hoursHand == null || minutesHand == null || secondsHand == null) {
            Debug.LogError("Please assign the clock hands in the inspector.");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        DateTime time = DateTime.Now;
        float currentSeconds = time.Second;
        float currentMinutes = time.Minute;
        float currentHours = (time.Hour % 12) + (currentMinutes / 60f);

        ApplyRotation(currentHours, currentMinutes, currentSeconds);
    }

    private void ApplyRotation(float hours, float minutes, float seconds)
    {
        //TODO: apply rotation
        hoursHand.localRotation = Quaternion.Euler(baseRotation.x + (hours * hoursToDegrees), baseRotation.y, baseRotation.z);
        minutesHand.localRotation = Quaternion.Euler(baseRotation.x + (minutes * minutesToDegrees), baseRotation.y, baseRotation.z);
        secondsHand.localRotation = Quaternion.Euler(baseRotation.x + (seconds * secondsToDegrees), baseRotation.y, baseRotation.z);
    }
}