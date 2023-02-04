using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_attributes : MonoBehaviour
{
    public List<GameObject> att_list;
    public List<GameObject> attributeLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void update_att_vis()
    {
        for (int i = 0; i < 5; i++)
        {
            // Destroy (all) children
            for (int j = attributeLocations[i].transform.childCount - 1; j >= 0; j--)
            {
                Object.Destroy(attributeLocations[i].transform.GetChild(j).gameObject);
            }
        }
        att_list = this.GetComponent<AllAttributes>().attributes;
        var index = 0;
        foreach (GameObject att in att_list)
        {
            var attribute = Object.Instantiate(att, attributeLocations[index].transform);
            index++;
        }
    }
}
