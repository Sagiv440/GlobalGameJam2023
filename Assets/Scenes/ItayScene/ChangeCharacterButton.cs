using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterButton : MonoBehaviour
{
    public List<GameObject> attributeLocations;
    public List<GameObject> possibleAttributes;
    public int attributeCount = 2;

    public Character character;

    private AllAttributes allAttributes;

    public void Awake()
    {
        allAttributes = GameObject.FindGameObjectWithTag(Tags.ALL_ATTRIBUTES).GetComponent<AllAttributes>();
    }

    public void OnClick()
    {
        Debug.Log("Changing character...");
        // Clear stats
        for (int i = 0; i < 5; i++)
        {
            // Destroy (all) children
            character.attributes.Clear();
            for (int j = attributeLocations[i].transform.childCount - 1; j >= 0; j--)
            {
                Object.Destroy(attributeLocations[i].transform.GetChild(j).gameObject);
            }
        }
        // Reroll stats
        for (int i = 0; i < attributeCount; i++)
        {
            var attributeIndex = Random.Range(0, possibleAttributes.Count - 1);
            var attribute = Object.Instantiate(possibleAttributes[attributeIndex], attributeLocations[i].transform);
            character.attributes.Add(attribute);
        }
        // Update AllAttributes
        allAttributes.ApplyAttributes();
    }
}
