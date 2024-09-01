using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public bool IsDisplayed = false;

    void Start()
    {
        gameObject.SetActive(false);
    }


    public void Setup()
    {
        gameObject.SetActive(true);
        IsDisplayed = true;
    }

    public void Setdown()
    {
        gameObject.SetActive(false);
        IsDisplayed = false;
    }
}
