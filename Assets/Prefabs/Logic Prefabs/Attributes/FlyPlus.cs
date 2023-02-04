using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlus : Attribute
{
    override public void Apply(GameObject character)
    {
        if (!character.GetComponent<Character>().firstFly)
            character.GetComponent<Character>().firstFly = true;
        else
            character.GetComponent<Character>().flyEnabled = true;
    }
}
