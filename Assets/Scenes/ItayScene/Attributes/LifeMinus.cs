using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMinus : Attribute
{
    override public void Apply(GameObject character)
    {
        character.GetComponent<Character>().health /= 1.22f;
    }
}
