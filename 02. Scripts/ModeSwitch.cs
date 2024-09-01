using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{
    public GameObject currentCanvas; // ���� ���̴� ������
    public GameObject otherCanvas; // ������ ������

    // ��ư Ŭ�� �� ȣ��� �޼ҵ�

    void Start()
    {
        currentCanvas.SetActive(true);
        otherCanvas.SetActive(false);
    }
    public void SwitchCanvas()
    {
        currentCanvas.SetActive(false); // ���� �������� ����
        otherCanvas.SetActive(true); // �ٸ� �������� ������
    }
}
