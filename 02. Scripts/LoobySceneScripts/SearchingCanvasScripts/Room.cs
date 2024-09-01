using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Room : MonoBehaviour
{
    // 방 제목 객체
    public TMP_Text roomTitle;

    // 개별 룸 클릭 시, 해당 게임 방 들어가는 함수
    // (PhotonNetwork.JoinRoom() 실행 후 -> LobbySceneMananger.cs_ public override OnJoinedRoom() 실행)
    public void JoinRoom(){
        print("Room.cs JoinRoom");
        GameObject.Find("Looby Manager").GetComponent<LobbySceneManager>().JoinRoomInList(roomTitle.text);
    }
}
