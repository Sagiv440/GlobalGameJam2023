using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMg : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private float TimeLeft;

    private Timer tm;
    private float carCarTime;
    

    // Start is called before the first frame update
    void Awake()
    {
        GameStateMangment.game_state = GAME_STATE.VIEW;
        if (GameStateMangment.Returned == 1)
        {
            carCarTime = TimeLeft - (int)GameStateMangment.Timer_timeLeft;
        }
        else
        {
            carCarTime = TimeLeft;
        }
        tm = new Timer(carCarTime);
        GameStateMangment.Returned = 0;
        tm.ActivateTimer();
    }

    // Update is called once per frame
    void Update()
    {

        TextTime.text = ""+(TimeLeft - (int)tm.GetCurrentTime());

        if (tm.IsTimerEnded()){
            GameStateMangment.game_state = GAME_STATE.PLAY;
            SceneManager.LoadScene("Level_1");
        }
        tm.SubtractTimerByValue(Time.deltaTime);
    }

    public void ViewLevel()
    {
        GameStateMangment.game_state = GAME_STATE.VIEW;
        GameStateMangment.Timer_timeLeft = carCarTime -tm.GetCurrentTime();
        GameStateMangment.Returned = 1;
        SceneManager.LoadScene("Level_1");
    }
}
