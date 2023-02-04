using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDelete : MonoBehaviour
{
    [SerializeField] private float D_time = 2f;
    private Timer DeleteTimer;

    private void Awake()
    {
        DeleteTimer = new Timer(D_time);
        DeleteTimer.ActivateTimer();
    }
    private void Update()
    {
        if(DeleteTimer.IsTimerEnded())
        {
            Destroy(this.gameObject);
        }
        DeleteTimer.SubtractTimerByValue(Time.deltaTime);
    }
}
