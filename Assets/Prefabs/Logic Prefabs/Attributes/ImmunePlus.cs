using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunePlus : Attribute
{
    override public void Apply(GameObject character)
    {
        if (!character.GetComponent<Character>().firstImmune)
            character.GetComponent<Character>().firstImmune = true;
        else
            character.GetComponent<Character>().immuneEnabled = true;
    }
}
