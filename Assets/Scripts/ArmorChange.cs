using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorChange : MonoBehaviour
{
    private GameManager gm;
    private CharacterController chc;

    [SerializeField] private GameObject hood;
    [SerializeField] private GameObject cape;
    [SerializeField] private GameObject belt;
    [SerializeField] private GameObject shoulders;
    [SerializeField] private GameObject wings;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject stafe;
    [SerializeField] private GameObject bolt1;
    [SerializeField] private GameObject bolt2;


    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        chc = GetComponent<CharacterController>();

        hood.SetActive(false);
        cape          .SetActive(false);
        belt          .SetActive(false);
        shoulders      .SetActive(false);
        wings         .SetActive(false);
        shield        .SetActive(false);
        stafe         .SetActive(false);
        bolt1         .SetActive(false);
        bolt2         .SetActive(false);
    }

    public void SetArmor()
    {
        if(chc.evasionEnabled)
        {
            bolt1.SetActive(true);
            bolt2.SetActive(true);
        }
        if (chc.speed > 2.2f)
        {
            cape.SetActive(true);
        }
        if (chc.immuneEnabled)
        {
            shield.SetActive(true);
            belt.SetActive(true);
            shoulders.SetActive(true);
        }
        if(chc.attackEnabled)
        {
            hood.SetActive(true);
            stafe.SetActive(true);
        }
        if (chc.flyEnabled)
        {
            wings.SetActive(true);
        }
    }
}
