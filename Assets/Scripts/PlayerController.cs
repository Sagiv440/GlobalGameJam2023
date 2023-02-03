using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] public GameObject Sponers;
    [SerializeField] private float sponeDelay = 2.0f;
    [SerializeField] private int ArmyCount = 5;

    private Timer SponeTimer;


    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        SponeTimer = new Timer(sponeDelay);
        SponeTimer.ActivateTimer();
    }

    private void Update()
    {
        if (SponeTimer.IsTimerEnded() == true && ArmyCount > 0)
        {
            //Fire

            gm.Charecters.Add(Instantiate(Sponers, gm.Start_Point.transform));
            SponeTimer.SetTimerTime(sponeDelay);
            SponeTimer.ActivateTimer();
            ArmyCount--;

        }
        SponeTimer.SubtractTimerByValue(Time.deltaTime);
    }

}
