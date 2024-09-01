using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MakingRoom : MonoBehaviourPunCallbacks
{
    public LobbySceneManager lobbySceneManager;
    public GameObject makingMapCanvas;

    [Header("Selected Mod Map IMG")]
    public GameObject modePanel;
    public GameObject mapPanel;

    [Header("Room Options")]
    public TMP_InputField roomTitleInput;
    public Button publicButton;
    public Button privateButton;
    public Slider numberSlider;
    public TMP_Text numberText;

    // 방 옵션 (인원 수) 데이터
    int numberplayer = 3;
    // 공개 비공개 데이터
    bool publicOption = true;

    private void Start() {
        // 앞에서 선택한 모드 이미지 출력
        Debug.Log("[MakingRoom.cs] lobbySceneManager.modeImage : " + lobbySceneManager.modeImage);
        Image modeImg = modePanel.GetComponent<Image>();
        modeImg.sprite = lobbySceneManager.modeImage;

        // 앞에서 선택한 맵 이미지 출력
        Debug.Log("[MakingRoom.cs] lobbySceneManager.mapImage : " + lobbySceneManager.mapImage);
        Image mapImg = mapPanel.GetComponent<Image>();
        mapImg.sprite = lobbySceneManager.mapImage;

        // 인원 수 슬라이드 바
        numberSlider.onValueChanged.AddListener((n) => {
            numberplayer = (int)n;
            numberText.text = n.ToString("0");
        });
    }

    // 뒤로 가기 (Making Map Canvas 이동)
    public void BackToLobbyRoom(){
        makingMapCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    // 공개 비공개 버튼 토글
    public void ClickToggleButton(Button selectButton){
        if(selectButton == publicButton){
            publicButton.image.color = Color.green;
            privateButton.image.color = Color.white; 
            publicOption = true;
            Debug.Log("Public Button 클릭 : " + selectButton);
        }
        else if(selectButton == privateButton){
            publicButton.image.color = Color.white;
            privateButton.image.color = Color.green; 
            publicOption = false;
            Debug.Log("Private Button 클릭 : " + selectButton);
        }
    }

    // 게임 방 생성하기 클릭
    public void ClickGoToGameLobbyScene(){
        CreatedRoom();
    }

    // 게임 방 생성하는 함수
    // (PhotonNetwork.CreateRoom() 실행 후 -> LobbySceneMananger.cs_ public override OnJoinedRoom() 실행)
    public void CreatedRoom()
    {
        // 방제 , 인원 수, 비공개/공개 , 입장허용 , 나머지 옵션 default
        PhotonNetwork.CreateRoom(roomTitleInput.text,
            new RoomOptions() {MaxPlayers = numberplayer, IsVisible = publicOption, IsOpen = true}, 
            TypedLobby.Default, null);
    }
}
