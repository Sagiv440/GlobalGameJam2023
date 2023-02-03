using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlus : Attribute
{
    override public void Apply(GameObject character)
    {
        character.GetComponent<Character>().health *= 3;
    }
}
