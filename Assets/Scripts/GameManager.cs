using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> Charecters;


    

    private void Awake()
    {
        GameObject[] sr = GameObject.FindGameObjectsWithTag(Tags.CHARACTERS);
        foreach(GameObject cr in sr)
        {
            Charecters.Add(cr);
        }
    }

    public void RemoveCaracters(GameObject Character)
    {
        Charecters.Remove(Character);
    }
}


