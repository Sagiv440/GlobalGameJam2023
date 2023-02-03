using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAttributes : Character
{
    public List<Character> parents;

    public void ApplyAttributes()
    {
        ResetAttributes();
        foreach (var parent in parents)
        {
            foreach (var attribute in parent.attributes)
            {
                attribute.GetComponent<Attribute>().Apply(this.gameObject);
            }
            
        }
    }
}
