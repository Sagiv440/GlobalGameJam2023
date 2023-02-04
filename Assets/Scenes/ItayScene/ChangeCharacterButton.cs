using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ChangeCharacterButton : MonoBehaviour
{
    AudioSource audioData;
    public List<GameObject> attributeLocations;
    public List<GameObject> possibleAttributes;
    public int attributeCount = 2;

    public Character character;

    private AllAttributes allAttributes;

    public void Awake()
    {
        audioData = GetComponent<AudioSource>();
        allAttributes = GameObject.FindGameObjectWithTag(Tags.ALL_ATTRIBUTES).GetComponent<AllAttributes>();
        OnClick();
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
    public void music_click()
    {
        audioData.Play(0);
    }
}
