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
        carList = "";
        count = 0;
        typeTimer = new Timer(typeTime);
        typeTimer.ActivateTimer();

        totrial = new List<string>();

        totrial.Add("Oh so you are the new general! you either brave or stupid non the less You are not prepared for this Crusade");
        totrial.Add("Well there is no turning back so listen UP!\n we were orderd by the king to hunt down the devil himself.");
        totrial.Add("I cant say I could have found a better candidate. probably because no one is stupid enough to volunteer");
        totrial.Add("did you ever wonder how much fucked up is fucked up ? because you are very much Fucked up");
        totrial.Add("your mission is to lead an assualte on the devile's keep ,his favorite methead defence is Tower defence,cachy eh? now in order to survive thise onslaught you the canon fodd..i meam herose were chosen   ");
        totrial.Add("In order to win you must refine the most efficient for the job.");
        totrial.Add("A natural talet of a soldier is is determent by his famely roots");
        totrial.Add("   Magic: give your soldiers range abilties to     bring down the towers\n     Life: Make your man more resistance to      Damage\n     Strangth: Incress the Fiscal capabiltis of        your soldier\n      Fly: A soldier will have the abilty to       clear gaps int dog defences.");
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

        if(index == 4)
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

        if (index == 6)
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

        if (index == 7)
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
            SceneManager.LoadScene("noaScene");
        }
    }
}
