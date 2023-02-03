using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class End_Game_Menu : MonoBehaviour
{
    Timer eTime;
    int state = 0;


    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Credit;

    [SerializeField] GameObject ReturnButton;

    private fadingText _Title;
    private fadingText _Score;
    private fadingText _Credit;
    private float tm = 2.0f;

    // Start is called before the first frame update
    void Awake()
    {
        eTime = new Timer(2.0f);
        eTime.ActivateTimer();

        _Title = new fadingText(Title);
        _Score = new fadingText(Score);
        _Credit = new fadingText(Credit);

        _Title.init();
        _Score.init();
        _Credit.init();

        ReturnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case 0:
                _Title.update(Time.deltaTime);
                break;

            case 1:
                _Score.update(Time.deltaTime);
                break;

            case 2:
                _Credit.update(Time.deltaTime);
                break;
                tm = 1.0f;
            case 3:
                ReturnButton.SetActive(true);
                break;
        }
        if(eTime.IsTimerEnded() && state < 4)
        {
            state++;
            eTime.SetTimerTime(tm);
            eTime.ActivateTimer();
        }
        eTime.SubtractTimerByValue(Time.deltaTime);
    }

    public void ReutrnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
class fadingText
{
    TextMeshProUGUI text;
    Timer t;
    public fadingText(TextMeshProUGUI txt)
    {
        text = txt;
        t = new Timer(1.0f);
    }
    public void init()
    {
        t.ActivateTimer();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
    public void update(float time)
    {
        if (t.IsTimerActive())
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, t.GetCurrentTime());
            t.SubtractTimerByValue(time);
        }
    }
}
