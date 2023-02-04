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
    int st = 0;


    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI creditTo;

    [SerializeField] TextMeshProUGUI[] Credits;
    [SerializeField] RawImage[] CreditsImg;

    [SerializeField] GameObject ReturnButton;

    private fadingText _Title;
    private fadingText _CreditTo;
    private fadingText[] _Credit;
    private fadingImage[] _CreditsImg;
    private float tm = 2.0f;

    // Start is called before the first frame update
    void Awake()
    {
        eTime = new Timer(2.0f);
        eTime.ActivateTimer();

        _Title = new fadingText(Title);
        _CreditTo = new fadingText(creditTo);

        _Credit = new fadingText[Credits.Length];
        _CreditsImg = new fadingImage[CreditsImg.Length];

        for(int i = 0; i < Credits.Length; i++)
        {
            _Credit[i] = new fadingText(Credits[i]);
            _Credit[i].init();
        }
        for (int i = 0; i < CreditsImg.Length; i++)
        {
            _CreditsImg[i] = new fadingImage(CreditsImg[i]);
            _CreditsImg[i].init();
        }


        _Title.init();
        _CreditTo.init();

        ReturnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case 0:
                _Title.update(Time.deltaTime);
                if (eTime.IsTimerEnded() && state < 4)
                {
                    state = 1;
                    eTime.SetTimerTime(tm);
                    eTime.ActivateTimer();
                }
                break;

            case 1:
                _CreditTo.update(Time.deltaTime);
                if (eTime.IsTimerEnded() && state < 4)
                {
                    state = 2;
                    eTime.SetTimerTime(tm);
                    eTime.ActivateTimer();
                }
                break;

            case 2:
                _Credit[st].update(Time.deltaTime);
                _CreditsImg[st].update(Time.deltaTime);
                if (eTime.IsTimerEnded() && state < 4)
                {
                    st++;
                    if (st == _Credit.Length) 
                        state = 3;
                    eTime.SetTimerTime(tm);
                    eTime.ActivateTimer();
                }
                break;
            case 3:
                ReturnButton.SetActive(true);
                break;
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

class fadingImage
{
    RawImage image;
    Timer t;
    public fadingImage(RawImage img)
    {
        image = img;
        t = new Timer(1.0f);
    }
    public void init()
    {
        t.ActivateTimer();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }
    public void update(float time)
    {
        if (t.IsTimerActive())
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, t.GetCurrentTime());
            t.SubtractTimerByValue(time);
        }
    }
}
