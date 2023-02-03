using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private float AttackRadius;
    [SerializeField] private float Damage_Amount;

    [SerializeField] private float AttackTime = 1.2f;
    [SerializeField] private float TowerHight = 4f;

    [SerializeField] private GameObject Target_0 = null;

    private Timer AttackTimer;


    private void init_Timers()
    {
        AttackTimer = new Timer(AttackTime);
        AttackTimer.ActivateTimer();
    }

    private void update_Timers()
    {
        
    }

    private void Awake()
    {
        init_Timers();
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        Target_0 = null;
    }

    private void ScanForTargets()
    {
        foreach (GameObject cr in gm.Charecters)
        {
            //Is in Range
            if (CommonFunctions.IsClose(cr.transform.position, this.transform.position, AttackRadius, TowerHight) == true)
            {
                if (Target_0 == null)
                {
                    Target_0 = cr;
                }
            }
            else if (cr == Target_0)
            {
                Target_0 = null;
            }
        }
    }

    private void AttackTarget()
    {
        if(Target_0 != null)
        {
            if (AttackTimer.IsTimerEnded() == true)
            {
                //Fire
                // Debug.Log("Attack Target");
                Target_0.GetComponent<CharacterController>().TackDamage(Damage_Amount);
                AttackTimer.SetTimerTime(AttackTime);
                AttackTimer.ActivateTimer();

            }
            AttackTimer.SubtractTimerByValue(Time.deltaTime);
        }
    }

    void Update()
    {
        if (gm.gameState == GAME_STATE.PLAY)
        {
            ScanForTargets();
            AttackTarget();
        }
    }
}
