using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activate()
    {
        GameStateMangment.game_state = GAME_STATE.PLAY;
    }
}
