using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour
{
    public Button leftBtn, rightBtn;

    public List<Transform> characterBuffer;

    bool updateUI;

    int currentindex;

    void Start()
    {
        UpdateUI();
        UpdateCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateUI)
        {
            updateUI = false;
            UpdateUI();
        }
        
    }

    void UpdateUI()
    {
        leftBtn.interactable = currentindex > 0;
        rightBtn.interactable = currentindex < characterBuffer.Count - 1;
    }

    void UpdateCharacter()
    {
        for (int i = 0; i < characterBuffer.Count; i++)
        {
            characterBuffer[i].gameObject.SetActive(i == currentindex);
        }
    }

    public void SwitchCharacter(bool leftOrRight)
    {
        currentindex += leftOrRight ? -1 : 1;
        updateUI = true;

        UpdateCharacter();
    }
}
