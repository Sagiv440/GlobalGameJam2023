using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameManager gm;
    private AllAttributes attributesHolder;

    [SerializeField] private TextMeshProUGUI GameOver;

    [SerializeField] public GameObject Sponers;
    [SerializeField] private float sponeDelay = 1.0f;
    [SerializeField] private int ArmyCount = 15;
    [SerializeField] private int baseArmyCount = 15;

    [SerializeField] GameObject ReturnButton;

    private SmartSwitch st;

    private Timer SponeTimer;
    private Timer EndGameTimer;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        try
        {
            attributesHolder = GameObject.FindGameObjectWithTag(Tags.ALL_ATTRIBUTES).GetComponent<AllAttributes>();
        }
        catch {}
        SponeTimer = new Timer(sponeDelay);
        SponeTimer.ActivateTimer();

        EndGameTimer = new Timer(4.0f);
        EndGameTimer.ActivateTimer();

        st = new SmartSwitch(false);
    }

    private void Start()
    {
        if(GameStateMangment.game_state == GAME_STATE.PLAY)
        {
            Debug.Log("Loaded stats. Speed, health: " + GameStateMangment.tln.speed.ToString() + ", " + GameStateMangment.tln.health.ToString());
            attributesHolder.SetAtributes(GameStateMangment.tln);
            SetGameStatePlay();
        }
    }

    private void Update()
    {
        switch(gm.gameState)
        {
            case GAME_STATE.VIEW:
                ReturnButton.SetActive(true);
                break;

            case GAME_STATE.PLAY:
                ReturnButton.SetActive(false);
                if (SponeTimer.IsTimerEnded() == true && ArmyCount > 0)
                {
                    //Fire
                    var character = Instantiate(Sponers, gm.Start_Point.transform);
                    if (attributesHolder != null)
                    {
                        character.GetComponent<CharacterController>().SetAtributes(new talents() { speed = attributesHolder.speed, health = attributesHolder.health, evasionEnabled = attributesHolder.evasionEnabled, evasionModifier = attributesHolder.evasionModifier, flyEnabled = attributesHolder.flyEnabled, attackEnabled = attributesHolder.attackEnabled, attackDamage = attributesHolder.attackDamage, attackTime = attributesHolder.attackTime, immuneEnabled = attributesHolder.immuneEnabled });
                        character.GetComponent<ArmorChange>().SetArmor();
                    }
                    SponeTimer.SetTimerTime(sponeDelay);
                    SponeTimer.ActivateTimer();
                    ArmyCount--;
                }
                SponeTimer.SubtractTimerByValue(Time.deltaTime);

                if(gm.Charecters.Count <= 0 && ArmyCount <= 0)
                {
                    gm.gameState = GAME_STATE.END;
                }
                break;

            case GAME_STATE.END:
                GameOver.color = new Color(1, 1, 1, EndGameTimer.GetCurrentTime());
                if (gm.Serviving_Characters.Count > 0)
                {
                    GameOver.text = "Good Work!";
                }
                else
                {
                    GameOver.text = "Game Over!";
                }
                
                if (EndGameTimer.IsTimerEnded())
                {
                    if (gm.Serviving_Characters.Count != 0)
                    {
                        GameStateMangment.talets = gm.Serviving_Characters;
                        GameStateMangment.Returned = 0;
                        GameStateMangment.Levels++;
                        if(GameStateMangment.Levels >= Levels.levels.Length)
                        {
                            SceneManager.LoadScene("CreditScene");
                        }
                        else
                        {
                            returnToView();
                        }
                    }
                    else
                    {
                        SceneManager.LoadScene("CreditScene");
                    }
                }
                EndGameTimer.SubtractTimerByValue(Time.deltaTime);
                st.Update(true);
                break;
        }

        if(gm.Charecters.Count == 0 && ArmyCount == 0)
        {
            gm.gameState = GAME_STATE.END;
        }
    }

    public void SetGameStatePlay()
    {
        ArmyCount = baseArmyCount;
        gm.gameState = GAME_STATE.PLAY;
    }

    public void returnToView()
    {
        SceneManager.LoadScene("Level_tree");
    }
}
