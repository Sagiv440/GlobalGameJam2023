using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class animate_Parents_move : MonoBehaviour
{
    AudioSource audioData;
    public List<GameObject> Parents;
    public GameObject Tree;
    public int index = 0;
    public GameObject switch_left;
    public GameObject switch_right;
    public float speed = 10f;
    public Vector3 destination_right;
    public Vector3 destination_left; 
    public Vector3 center; 
    public string move ="center";

    private float_lerp treelerp;
    private SmartSwitch treeSwitch;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        treelerp = new float_lerp(Tree.transform.position.x, Tree.transform.position.x);
        treeSwitch = new SmartSwitch(false);
        //Button thisbutton = this.GetComponent<Button>();
		//thisbutton.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(index==0)
        {
            switch_left.SetActive(false);
            switch_right.gameObject.SetActive(true);
            
        }
        else if(index==Parents.Count-1)
        {
            switch_right.SetActive(false);
            switch_left.gameObject.SetActive(true);
        }
        else
        {
            switch_left.gameObject.SetActive(true);
            switch_right.gameObject.SetActive(true);
        }
        Vector3 carPos = new Vector3(treelerp.UpdateTimer(Time.deltaTime), Tree.transform.position.y, Tree.transform.position.z);
        Tree.transform.position = carPos;

        treeSwitch.Update(treelerp.IsFinished());
        if(treeSwitch.OnPress()){
            if(move == "right"){
                treelerp.setStart(destination_right.x);
                treelerp.setEnd(center.x);
                treelerp.StartLerp();
                move="center";
            }
            else if(move == "left"){
                treelerp.setStart(destination_left.x);
                treelerp.setEnd(center.x);
                treelerp.StartLerp();
                move="center";
            }
            else if(move=="center")
            {
                Parents[index].SetActive(true);
            }
        }

        /*
        if(move=="center")
        {
            Tree.transform.position = Vector3.Lerp(Tree.transform.position, center, Time.deltaTime);
        }
        else if(move=="right" && Tree.transform.position!=destination_left)
        {
            Tree.transform.position = Vector3.Lerp(Tree.transform.position, destination_left, Time.deltaTime);
        }
        else if(move=="right" && Tree.transform.position==destination_left)
        {
            Tree.transform.position = destination_right;
            move="center";
        }
        else if(move=="left" && Tree.transform.position!=destination_right)
        {
            Tree.transform.position = Vector3.Lerp(Tree.transform.position, destination_right, Time.deltaTime);
        }
        else if(move=="left" && Tree.transform.position==destination_right)
        {
            Tree.transform.position = destination_left;
            move="center";
        }
        */
    }

    public void onClick(Button button)
    {
        audioData.Play(0);
        if(button.name=="Switch_branch_right")
        {
            Parents[index].SetActive(false);
            index += 1;
            move="right";
            Debug.Log(index);
            treelerp.setStart(center.x);
            treelerp.setEnd(destination_left.x);
            treelerp.StartLerp();
            
        }
        if(button.name=="Switch_branch_left")
        {
            Parents[index].SetActive(false);
            move="left";
            index -= 1;
            Debug.Log(index);
            treelerp.setStart(center.x);
            treelerp.setEnd(destination_right.x);
            treelerp.StartLerp();
        }

    }

}
