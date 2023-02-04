using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMg : MonoBehaviour
{
    [SerializeField] private float TimeLeft;

    private Timer tm;

    // Start is called before the first frame update
    void Awake()
    {
        GameStateMangment.game_state = GAME_STATE.VIEW;
        tm = new Timer(TimeLeft);
        tm.ActivateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(tm.IsTimerEnded()){
            GameStateMangment.game_state = GAME_STATE.PLAY;
            SceneManager.LoadScene("Level_1");
        }
        tm.SubtractTimerByValue(Time.deltaTime);
    }
}
