using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Totorial : MonoBehaviour
{
    [SerializeField] private float typeTime = 0.2f;
    [SerializeField] private TextMeshProUGUI Tot;
    private List<string> totrial;
    private string carList;

    private int count = 0;
    private int index = 0;
    private Timer typeTimer;
    

    private void Awake()
    {
        carList = "";
        count = 0;
        typeTimer = new Timer(typeTime);
        typeTimer.ActivateTimer();

        totrial = new List<string>();

        totrial.Add("Oh so you are the new general! you either brave or stupid non the less You are not prepared for this Crusade");
        totrial.Add("Well there is no turning back so listen UP!\n we were orderd by the king to hunt down the devil himself.");
        totrial.Add("I cant say I could have found a better candidate. probably because no one is stupid enough to volunteer");
        totrial.Add("did you ever wonder how much fucked up is fucked up ? because you are very much Fucked up");

    }

    private void Update()
    {
        if (typeTimer.IsTimerEnded() && totrial[index].Length > count)
        {
            carList += totrial[index][count];
            Tot.text = carList;
            count++;
            typeTimer.SetTimerTime(typeTime);
            typeTimer.ActivateTimer();
        }
        typeTimer.SubtractTimerByValue(Time.deltaTime);
    }

    public void nextLine()
    {
        carList = "";
        count = 0;
        index++;
        typeTimer.SetTimerTime(typeTime);
        typeTimer.ActivateTimer();
    }
}
