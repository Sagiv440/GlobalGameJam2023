using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject End_Point;
    [SerializeField] public GameObject Start_Point;
    [SerializeField] public GAME_STATE gameState = GAME_STATE.PLAY;

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
        this.tag = Tags.GAME_MANAGER;
        Start_Point = GameObject.FindGameObjectWithTag(Tags.STARTPOINT);
        End_Point = GameObject.FindGameObjectWithTag(Tags.ENDPOINT);
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


