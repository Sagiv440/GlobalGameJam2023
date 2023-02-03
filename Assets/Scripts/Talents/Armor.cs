using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Talent
{
    public Armor(GameManager gm, CharacterController chc) : base(gm, chc) { }
    override public T_TYPES Get_Type() { return T_TYPES.ARMOR; }
}
