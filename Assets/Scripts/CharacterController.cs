using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] private GameObject Target_0;

    [SerializeField] public float Speed = 3.5f;
    [SerializeField] private float SpottingRadiuse = 2.0f;
    [SerializeField] private float AttackTime;
    [SerializeField] private float Damage_Amount;

    [SerializeField] public List<Talent> talent;

    private Timer AttackTimer;

    private void talentLog()
    {
        
        foreach(Talent t in talent)
        {
            Debug.Log("charecter: "+this.ToString()+" Talent type: " + t.Get_Type());
        }
    }

    private void ApplyTalents()
    {

        foreach (Talent t in talent)
        {
            t.Apply_Talent();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;

        Target_0 = null;

        AttackTimer = new Timer(AttackTime);
        AttackTimer.ActivateTimer();
        talent = new List<Talent>();
        talent.Add(new Speed(gm, this, 120.0f));
        talent.Add(new Armor(gm, this));

        talentLog();
        ApplyTalents();
    }

    void Attack_logic()
    {
        if(Target_0 != null)
        {
            agent.SetDestination(Target_0.transform.position);
            if(CommonFunctions.IsClose(Target_0.transform.position, this.transform.position, agent.stoppingDistance))
            {
                if (AttackTimer.IsTimerEnded() == true)
                {
                    //Fire

                    Debug.Log("Attack Tower: "+Target_0);
                    Target_0.GetComponent<Status>().TackDamage(Damage_Amount);
                    AttackTimer.SetTimerTime(AttackTime);
                    AttackTimer.ActivateTimer();

                }
                AttackTimer.SubtractTimerByValue(Time.deltaTime);
            }
        }
        else
        {
            agent.SetDestination(gm.target.transform.position);
        }
    }

    void ScanTarggets()
    {
        foreach (GameObject cr in gm.Towers)
        {
            //Is in Range
            if (CommonFunctions.IsClose(cr.transform.position, this.transform.position, SpottingRadiuse) == true)
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

    // Update is called once per frame
    void Update()
    {
        Attack_logic();
        ScanTarggets();
    }
}
