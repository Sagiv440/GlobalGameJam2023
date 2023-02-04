using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlus : Attribute
{
    override public void Apply(GameObject character)
    {
        if (!character.GetComponent<Character>().attackEnabled)
            character.GetComponent<Character>().attackEnabled = true;
        else
            character.GetComponent<Character>().attackDamage *= 1.6f;
    }
}
