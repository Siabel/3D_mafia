using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public GameObject currentCanvas; // 현재 보이는 컨버스
    public GameObject otherCanvas; // 보여줄 컨버스

    // 버튼 클릭 시 호출될 메소드

    void Start()
    {
        currentCanvas.SetActive(true);
        otherCanvas.SetActive(false);
    }
    public void SwitchCanvas()
    {
        currentCanvas.SetActive(false); // 현재 컨버스를 숨김
        otherCanvas.SetActive(true); // 다른 컨버스를 보여줌
    }
}
