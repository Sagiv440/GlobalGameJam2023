using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] public float Helth;
    [SerializeField] public Animator anim = null;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip[] DeathSound;
    private GameManager gm;

    private SmartSwitch DeathSwitch;
    private Timer deathTimer;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        deathTimer = new Timer(3f);
        DeathSwitch = new SmartSwitch(false);
    }

    private void Update()
    {
        if (deathTimer.IsTimerEnded())
        {
            gm.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        if (deathTimer.IsTimerActive())
            deathTimer.SubtractTimerByValue(Time.deltaTime);
    }

    private void Die()
    {
        if (anim == null)
        {
            gm.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            DeathSwitch.Update(true);
            if (DeathSwitch.OnPress())
            {
                AS.PlayOneShot(DeathSound[Random.Range(0, DeathSound.Length)]);
                anim.SetBool("isDead", true);
                deathTimer.ActivateTimer();
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }

    public void TackDamage(float damage)
    {
        // Debug.Log("Taking Damage");
        Helth -= damage;
        if (Helth <= 0.0f)
        {
            Die();
        }
    }
}
