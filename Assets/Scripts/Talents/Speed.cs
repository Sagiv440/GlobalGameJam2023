using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Talent
{
    private float Speed_Modifer;
    public Speed(GameManager gm, CharacterController chc, float Speed) : base(gm, chc)
    {
        Speed_Modifer = Speed;
    }

    override public T_TYPES Get_Type() { return T_TYPES.SPEED; }

}
