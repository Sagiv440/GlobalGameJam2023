using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlus : Attribute
{
    override public void Apply(GameObject character)
    {
        if (!character.GetComponent<Character>().firstAttack)
            character.GetComponent<Character>().firstAttack = true;
        else
            character.GetComponent<Character>().attackEnabled = true;
    }
}
