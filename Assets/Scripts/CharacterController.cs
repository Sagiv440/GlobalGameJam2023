using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    public float speed = 1f;
    public float health = 1f;
    public bool evasionEnabled = false;
    public float evasionModifier = 1f;
    public bool flyEnabled = false;
    public bool attackEnabled = false;
    public bool immuneEnabled = false;

    [SerializeField] public NavMeshAgent agent;
    [SerializeField] private GameObject Target_0;

    [SerializeField] private float SpottingRadiuse = 2.0f;
    [SerializeField] private float AttackTime;
    [SerializeField] private float Damage_Amount;

    private Timer AttackTimer;

    public void SetAtributes(talents tln)
    {
        speed = tln.speed;
        health = tln.health;
        evasionEnabled = tln.evasionEnabled;
        evasionModifier = tln.evasionModifier;
        flyEnabled = tln.flyEnabled;
        attackEnabled = tln.attackEnabled;
        immuneEnabled = tln.attackEnabled;
    }

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        Target_0 = null;

        AttackTimer = new Timer(AttackTime);
        AttackTimer.ActivateTimer();
        Random.InitState((int)Time.unscaledTime);
    }

    public void TackDamage(float damage)
    {
        float car_dmg = damage;
        if(evasionEnabled == true)
        {
            float rand = Random.Range(100.0f, 0.0f);
            if(rand <= evasionModifier)
            {
                Debug.Log("Attack missed");
                car_dmg = 0.0f;
            }
        }

        this.GetComponent<CharacterController>().TackDamage(damage);
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
        if (attackEnabled == true)
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
    }

    // Update is called once per frame
    void Update()
    {
        Attack_logic();
        ScanTarggets();
    }
}
