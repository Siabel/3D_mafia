using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SearchingRoom : MonoBehaviourPunCallbacks
{
    // 현재 전체 방 리스트
    public GameObject[] AllRooms;

    // 방 제목 객체
    public TMP_Text roomTitle;

    [Header("Canvas Object")]
    public GameObject lobbyRoomCanvas;

    public Canvas searchingRoomCanvas;

    // 뒤로 가기 (Lobby Room Canvas 이동)
    public void BackToLobbyRoom(){
        lobbyRoomCanvas.SetActive(true);
        searchingRoomCanvas.enabled = false;
    }
}
