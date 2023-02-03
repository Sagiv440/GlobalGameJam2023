using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] public GameObject Sponers;
    [SerializeField] private float sponeDelay = 2.0f;
    [SerializeField] private int ArmyCount = 5;

    private SmartSwitch st;

    private Timer SponeTimer;


    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        SponeTimer = new Timer(sponeDelay);
        SponeTimer.ActivateTimer();

        st = new SmartSwitch(false);
    }

    private void Update()
    {
        switch(gm.gameState)
        {
            case GAME_STATE.VIEW:
                break;

            case GAME_STATE.PLAY:
                if (SponeTimer.IsTimerEnded() == true && ArmyCount > 0)
                {
                    //Fire

                    Instantiate(Sponers, gm.Start_Point.transform);
                    SponeTimer.SetTimerTime(sponeDelay);
                    SponeTimer.ActivateTimer();
                    ArmyCount--;

                }
                SponeTimer.SubtractTimerByValue(Time.deltaTime);

                if(gm.Charecters.Count <= 0 && ArmyCount <= 0)
                {
                    gm.gameState = GAME_STATE.END;
                }
                break;

            case GAME_STATE.END:
                if (st.OnEvent())
                {
                    GameStateMangment.talets = gm.Serviving_Characters;
                    gm.printServivers();
                }
                st.Update(true);
                break;
        }
    }

}
