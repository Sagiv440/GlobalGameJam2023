using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<GameObject> attributes;

    public float speed = 1f;
    public float health = 1f;
    public bool evasionEnabled = false;
    public float evasionModifier = 1f;
    public bool flyEnabled = false;
    public bool attackEnabled = false;
    public bool immuneEnabled = false;


    public void ApplyAttributes()
    {
        foreach(var attribute in attributes)
        {
            // attribute.GetComponent<Attribute>().Apply(this);
        }
    }
}
