using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasionPlus : Attribute
{
    override public void Apply(GameObject character)
    {
        if (!character.GetComponent<Character>().evasionEnabled)
            character.GetComponent<Character>().evasionEnabled = true;
        else
            character.GetComponent<Character>().evasionModifier /= 2;
    }
}
