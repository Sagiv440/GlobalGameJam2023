using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public List<GameObject> Charecters;
    [SerializeField] public List<GameObject> Towers;

    private List<GameObject> setCharList(string tag)
    {
        List<GameObject> Tagss = new List<GameObject>();
        GameObject[] sr = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject cr in sr)
        {
            Tagss.Add(cr);
        }
        return Tagss;
    }

    private void Awake()
    {
        ResetGameManager();
    }

    public void ResetGameManager()
    {
        Charecters = setCharList(Tags.CHARACTERS);
        Towers = setCharList(Tags.TOWERS);
    }

    public bool Remove(GameObject Character)
    {
        if (Character.tag == Tags.CHARACTERS) { return Charecters.Remove(Character); }
        if (Character.tag == Tags.TOWERS) { return Towers.Remove(Character); }
        return false;
    }
}


