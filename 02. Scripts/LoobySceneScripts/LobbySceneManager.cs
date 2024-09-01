using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class LobbySceneManager : MonoBehaviourPunCallbacks
{
    // 선택한 모드, 맵 이미지 데이터 저장
    [Header("Select Mode Map IMG Data")]
    public Sprite modeImage;
    public Sprite mapImage;

    [Header("Looby Scene")]
    public GameObject loobyRoomCanvas;

    [Header("Making Scene")]
    public GameObject makingModeCanvas;
    public GameObject makingMapCanvas;
    public GameObject makingRoomCanvas;

    [Header("Searching Scene")]
    public Canvas searchingRoomCanvas;





    // 모든 캔버스 off / 오직 로비 룸 캔버스만 on
    private void Start()    
    {
        loobyRoomCanvas.SetActive(true);
        makingModeCanvas.SetActive(false);
        makingMapCanvas.SetActive(false);
        makingRoomCanvas.SetActive(false);
        searchingRoomCanvas.enabled = false;
    }

    // 게임 방 리스트 조회
    public void JoinRoomInList(string RoomTitle)
    {
        print("LobbySceneManager.cs /joinRoomInlist");
        // OnJoinedRoom 콜백 함수
        PhotonNetwork.JoinRoom(RoomTitle);

    }

    // 1. Event 게임 방 입장 (InGameLobbyScene 입장)
    public override void OnJoinedRoom()
    {
        print("LobbySceneMananger.cs OnJoinedRoom");
        // base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("InGameLobbyScene");
    }

    // 1-2. Event 게임 방 입장 실패
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // base.OnJoinRoomFailed(returnCode, message);
        print("LobbySceneMananger.cs OnJoinRoomFailed : "  + returnCode + message);
    }



    // 방 리스트에 추가할 룸 프리팹
    public GameObject RoomPrefb;

    // 현재 전체 방 리스트 (향후 방 리스트 저장 후, 불러 올때 쓰일 예정)
    // public GameObject[] AllRooms;

    // 방 제목 객체
    public TMP_Text roomTitle;


    // 게임 방 리스트를 업데이트 시켜주는 Event 함수
    // 게임 방 생성 or 삭제 될 때, 해당 목록 만 업데이트 시켜준다.
    // (생성 => MakingRoom.cs _ CreatedRoom() / 삭제 => 포톤 자동 처리)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // base.OnRoomListUpdate(roomList);
        print("RoomList.cs OnRoomListUpdate");

        // 이전에 방 생성했던 쓰레기 데이터 제거 작업 (혹시 모르니깐 )
        // for(int i = 0; i < AllRooms.Length; i++){
        //     if(AllRooms[i] != null){
        //         Destroy(AllRooms[i]);
        //     }
        // }
        // AllRooms = new GameObject[roomList.Count];

        // 인슨턴스 룸 추가 (리얼 추가)
        for(int i = 0; i < roomList.Count; i++){
            
            // 공개 방이고, 현재 1명 이상 방에 들어가 있다면,
            if(roomList[i].IsOpen && roomList[i].IsVisible && roomList[i].PlayerCount >= 1){

                print("RoomList.cs : " + roomList[i].Name);
                GameObject Room = Instantiate(RoomPrefb, Vector3.zero, Quaternion.identity, GameObject.Find("Content").transform);
                Room.GetComponent<Room>().roomTitle.text =roomList[i].Name;

                // 전체 방 리스트에 넣기
                // AllRooms[i] = Room;
            }
        }
    }
}