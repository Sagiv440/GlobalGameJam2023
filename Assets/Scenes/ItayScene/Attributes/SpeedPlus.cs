using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlus : Attribute
{
    override public void Apply(GameObject character)
    {
        character.GetComponent<Character>().speed += 0.5f;
    }
}
