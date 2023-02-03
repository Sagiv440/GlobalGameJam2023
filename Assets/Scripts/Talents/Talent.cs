using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent
{
    protected GameManager gm;
    protected CharacterController chc;

    public Talent(GameManager gm, CharacterController chc)
    {
        this.gm = gm;
        this.chc = chc;
    }

    virtual public T_TYPES Get_Type() { return T_TYPES.VOID; }
    virtual public void Apply_Talent() { }

}
