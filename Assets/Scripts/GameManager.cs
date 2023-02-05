using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject End_Point;
    [SerializeField] public GameObject Start_Point;
    [SerializeField] public GameObject playerController;
    [SerializeField] public GAME_STATE gameState = GAME_STATE.PLAY;

    [SerializeField] public List<GameObject> Charecters;
    [SerializeField] public List<GameObject> Towers;

    [SerializeField] public float PerSpark = 4;
    [SerializeField] public GameObject Spark;
    [SerializeField] public float radius = 10;

    public List<talents> Serviving_Characters;

    private Timer sparkTime;

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
        Serviving_Characters = new List<talents>();
        this.tag = Tags.GAME_MANAGER;
        Start_Point = GameObject.FindGameObjectWithTag(Tags.STARTPOINT);
        End_Point = GameObject.FindGameObjectWithTag(Tags.ENDPOINT);
        playerController = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        sparkTime = new Timer(PerSpark);
        sparkTime.ActivateTimer();
        ResetGameManager();
    }

    private void Update()
    {
        if (sparkTime.IsTimerEnded() && Spark != null)
        {
            Vector2 vec = Random.insideUnitCircle;
            Vector3 pos = new Vector3(vec.x, 0, vec.y) * radius;
            Instantiate(Spark, pos, Quaternion.identity);
            sparkTime.SetTimerTime(Random.Range(0.01f, 0.5f));
            sparkTime.ActivateTimer();
        }
        sparkTime.SubtractTimerByValue(Time.deltaTime);
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

    public void printServivers()
    {
        foreach(talents t in Serviving_Characters)
        {
            Debug.Log("Charecter: Name  with speed: " + t.speed + ", Heath: " + t.health);
        }
    }
}


