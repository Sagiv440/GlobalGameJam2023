using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<GameObject> attributes;

    public float speed = 1f;
    public float health = 1f;
    public bool evasionEnabled = false;
    public float evasionModifier = 10f;
    public bool flyEnabled = false;
    public bool attackEnabled = false;
    public bool immuneEnabled = false;

    public bool firstFly = false;
    public bool firstAttack = false;
    public bool firstImmune = false;

    public void ResetAttributes()
    {
        speed = 1f;
        health = 1f;
        evasionEnabled = false;
        evasionModifier = 10f;
        flyEnabled = false;
        attackEnabled = false;
        immuneEnabled = false;
        firstFly = false;
        firstAttack = false;
        firstImmune = false;
    }
}
