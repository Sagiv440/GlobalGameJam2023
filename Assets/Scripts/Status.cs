using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] public float Helth;
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
    }

    private void Die()
    {
        Debug.Log("Is Dead: " + this.ToString());
        gm.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    public void TackDamage(float damage)
    {
        Debug.Log("Taking Damage");
        Helth -= damage;
        if (Helth <= 0.0f)
        {
            Die();
        }
    }
}
