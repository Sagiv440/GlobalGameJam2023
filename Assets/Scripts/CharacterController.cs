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
        agent.speed = speed;
        health = tln.health;
        evasionEnabled = tln.evasionEnabled;
        evasionModifier = tln.evasionModifier;
        flyEnabled = tln.flyEnabled;
        attackEnabled = tln.attackEnabled;
        immuneEnabled = tln.immuneEnabled;
        Damage_Amount = tln.attackDamage;
        AttackTime = tln.attackTime;
        agent.speed = speed;
        GetComponent<Status>().Helth = health;
    }

    public talents GetAtributes()
    {
        talents tln = new talents();
        tln.speed = speed;
        tln.health = health;
        tln.evasionEnabled = evasionEnabled;
        tln.evasionModifier = evasionModifier;
        tln.flyEnabled = flyEnabled;
        tln.attackEnabled = attackEnabled;
        tln.immuneEnabled = immuneEnabled;
        tln.attackDamage = Damage_Amount;
        tln.attackTime = AttackTime;
        return tln;
    }

    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        gm.Charecters.Add(this.gameObject);
        agent = GetComponent<NavMeshAgent>();

        Target_0 = null;
        AttackTimer = new Timer(AttackTime);
        AttackTimer.ActivateTimer();
        Random.InitState((int)Time.unscaledTime);

        // Cancel Turn [1]
        // agent.updateRotation = false;
    }


    void LateUpdate()
    {
        // Cancel Turn [2]

        // FaceTarget();

        //// if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        //// {
        ////     // transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        ////     // transform.rotation = Quaternion.LookRotation(agent.steeringTarget.normalized, Vector3.up);
        //// }
    }

    void FaceTarget()
    {
        var turnTowardNavSteeringTarget = agent.steeringTarget;
     
        Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
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

        this.GetComponent<Status>().TackDamage(car_dmg);
    }

    void Attack_logic()
    {
        if(Target_0 != null)
        {
            if (AttackTimer.IsTimerEnded() == true)
            {
                //Fire
                // Debug.Log("Attack Tower: " + Target_0);
                Target_0.GetComponent<Status>().TackDamage(Damage_Amount);
                AttackTimer.SetTimerTime(AttackTime);
                AttackTimer.ActivateTimer();

            }
            AttackTimer.SubtractTimerByValue(Time.deltaTime);
        }
    }

    void Retched_End()
    {
        if (CommonFunctions.IsClose(gm.End_Point.transform.position, this.transform.position, agent.stoppingDistance) == true)
        {
            Debug.Log("Uint: " + this.ToString() + " Has reished the End of the level");
            gm.Serviving_Characters.Add(GetAtributes());
            gm.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }


    void ScanTarggets()
    {
        if (attackEnabled == true)
        {
            Target_0 = null;
            foreach (GameObject cr in gm.Towers)
            {
                //Is in Range
                if (CommonFunctions.IsClose(cr.transform.position, this.transform.position, SpottingRadiuse) == true)
                {
                    if (Target_0 == null)
                    {
                        Target_0 = cr;
                        break;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState == GAME_STATE.PLAY)
        {
            ScanTarggets();
            Retched_End();
            Attack_logic();
            try
            {
                agent.SetDestination(gm.End_Point.transform.position);
            }
            catch
            { }
        }
    }
}
