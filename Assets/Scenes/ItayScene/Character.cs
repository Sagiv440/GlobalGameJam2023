using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<GameObject> attributes;

    public float speed = 1f;
    public float health = 1f;
    public bool evasionEnabled = false;
    public float evasionModifier = 25f;
    public bool flyEnabled = false;
    public bool attackEnabled = false;
    public float attackDamage = 8f;
    public float attackTime = 10f;
    public bool immuneEnabled = false;

    public bool firstFly = false;
    public bool firstAttack = false;
    public bool firstImmune = false;

    public float baseSpeed = 1f;
    public float baseHealth = 1f;
    public bool baseEvasionEnabled = false;
    public float baseEvasionModifier = 25f;
    public bool baseFlyEnabled = false;
    public bool baseAttackEnabled = false;
    public float baseAttackDamage = 8f;
    public float baseAttackTime = 10f;
    public bool baseImmuneEnabled = false;

    public bool baseFirstFly = false;
    public bool baseFirstAttack = false;
    public bool baseFirstImmune = false;

    public void ResetAttributes()
    {
        speed = baseSpeed;
        health = baseHealth;
        evasionEnabled = baseEvasionEnabled;
        evasionModifier = baseEvasionModifier;
        flyEnabled = baseFlyEnabled;
        attackEnabled = baseAttackEnabled;
        attackDamage = baseAttackDamage;
        baseAttackTime = baseAttackTime;
        immuneEnabled = baseImmuneEnabled;
        firstFly = baseFirstFly;
        firstAttack = baseFirstAttack;
        firstImmune = baseFirstImmune;
    }
}
