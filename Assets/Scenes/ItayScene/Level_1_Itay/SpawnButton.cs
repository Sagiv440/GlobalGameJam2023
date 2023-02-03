using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
    }

    public void OnClick()
    {
        gm.gameState = GAME_STATE.PLAY;
    }
}
