using System;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    private float shiftTime;
    public float ShiftTime { get { return shiftTime; } }
    public float ShiftTimeAsProportion { get { return Mathf.Clamp(shiftTime / SHIFT_DURATION, 0.0f, 1.0f); } }

    private const float SHIFT_DURATION = 75.0f;

    public Action OnShiftOver;


    public void StartShift()
    {
        shiftTime = SHIFT_DURATION;
    }

    private void Update()
    {
        shiftTime = Mathf.MoveTowards(shiftTime, 0.0f, Time.deltaTime);

        if (shiftTime == 0)
        {
            OnShiftOver?.Invoke();
        }
    }

}
