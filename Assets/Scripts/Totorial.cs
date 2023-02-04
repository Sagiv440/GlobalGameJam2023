using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Totorial : MonoBehaviour
{
    [SerializeField] private float typeTime = 0.2f;
    [SerializeField] private TextMeshProUGUI Tot;
    private List<string> totrial;
    private string carList;

    [SerializeField] RawImage[] Img_line5;
    [SerializeField] RawImage[] Img_line6;
    [SerializeField] RawImage[] Img_line7;

    private int count = 0;
    private int index = 0;
    private Timer typeTimer;


    private void Awake()
    {
        GameStateMangment.Levels = 0;
        carList = "";
        count = 0;
        typeTimer = new Timer(typeTime);
        typeTimer.ActivateTimer();
        

        totrial = new List<string>();

        totrial.Add("Oh, so you are the new general! you either brave or stupid to take on this mission");
        totrial.Add("Well, there is no turning back now, so listen UP!\n we were orderd by the king to hunt down the devil himself.");
        totrial.Add("your mission is to lead an assualte on the devil's realm. ");
        totrial.Add("In order to win, you must choose and imprive the most efficient soldiers for the job.");
        totrial.Add("The talet of a soldier is determent by his famely roots");
        totrial.Add("   Magic: gives your soldiers range abilties to bring down the towers\n     Life: Makes your soldiers more resistance to damage\n     Strangth: Increases the physical capabiltis of your soldier.");
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

        if(index == 3)
        {
            foreach(RawImage i in Img_line5)
            {
                i.enabled = true;
            }
        }
        else
        {
            foreach (RawImage i in Img_line5)
            {
                i.enabled = false;
            }
        }

        if (index == 4)
        {
            foreach (RawImage i in Img_line6)
            {
                i.enabled = true;
            }
        }
        else
        {
            foreach (RawImage i in Img_line6)
            {
                i.enabled = false;
            }
        }

        if (index == 5)
        {
            foreach (RawImage i in Img_line7)
            {
                i.enabled = true;
            }
        }
        else
        {
            foreach (RawImage i in Img_line7)
            {
                i.enabled = false;
            }
        }
    }

    public void nextLine()
    {
        if (index < totrial.Count-1)
        {
            carList = "";
            count = 0;
            index++;
            typeTimer.SetTimerTime(typeTime);
            typeTimer.ActivateTimer();
        }
        else
        {
            SceneManager.LoadScene("Level_tree");
        }
    }
}
