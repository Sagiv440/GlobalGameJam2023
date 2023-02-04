using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class moveScene : MonoBehaviour
{
    AudioSource audioData;
    public string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        audioData.Play(0);
        SceneManager.LoadScene(sceneName:scene_name);
    }
}
