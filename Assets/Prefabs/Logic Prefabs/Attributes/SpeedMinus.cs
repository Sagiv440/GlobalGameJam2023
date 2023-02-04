using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMinus : Attribute
{
    override public void Apply(GameObject character)
    {
        character.GetComponent<Character>().speed -= 1.5f;
    }
}

