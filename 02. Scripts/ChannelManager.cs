using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// public class ChannelManager : MonoBehaviour
public class ChannelManager : MonoBehaviourPunCallbacks
{
    public GameObject modalPanel; // 접속 실패할 경우의 모달 처리를 위해 생성

    void Start()
    {
        modalPanel.SetActive(false); // 처음에 모달 비활성화
    }
    public void ConnectToChannel(int channelNumber)
    {
        string appId = GetAppIdByChannel(channelNumber); // channelNumber에 맞는 appId 할당

        // 새로운 AppSettings 객체를 생성하고, AppIdRealtime을 설정
        AppSettings settings = new AppSettings()
        {
            AppIdRealtime = appId,
        };

        PhotonNetwork.ConnectUsingSettings(settings); // 포톤 서버 연결
    }

    // 서버 접속 실패
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log($"서버 접속 실패: {cause}"); // 서버 접속 실패 로그
        modalPanel.SetActive(true); // 접속 실패했으니 모달 UI를 보여준다.
    }

    public void ModalBtnClick() // 버튼 클릭하면 모달 꺼주는 역할
    {
        modalPanel.SetActive(false);
    }



    public void PlayerCounter() // 플레이어 수 확인함수
    {
        int playerCount = PhotonNetwork.CountOfPlayersOnMaster; // 마스터 서버에 있는 플레이어 수, 로비 포함
        Debug.Log("현재 로비에 있는 유저 수: " + playerCount);
    }

    private string GetAppIdByChannel(int channelNumber) // channelNumber를 받으면 AppId를 return
    {
        switch (channelNumber)
        {
            case 1: return "1bed5af5-423f-4e36-872f-365e84daed36"; // 준혁 App id PUN
            case 2: return "aa2de7f0-7461-498a-92c6-1b3c375c584f"; // 동호 App    
            case 3: return "d9302e11-06d7-49f0-8c92-ff23cec623c9"; // 현우 App
            case 4: return "f794b165-4232-4fb2-80af-3b441256c86d"; // 수현 App
            case 5: return "c8286018-b331-478d-a7ed-3749f12d7894"; // 원종 App
            case 6: return "b55a1d31-ae4b-43af-95b6-a200413aa09a"; // 소현 App

            default: return "null";
        }
    }

    private string GetChatAppIdByChannel(int channelNumber) // 나중에 채팅 구현할 경우 할당할 Chat 관련 AppId
    {
        // 이 메서드는 채널 번호에 따라 해당하는 AppId를 반환해야 합니다.
        switch (channelNumber)
        {
            case 1: return "받아야한다"; // 준혁 App id Chat
            case 2: return "받아야한다"; // 동호 App    
            case 3: return "27092388-5f9f-4aec-9f8b-83d65f965f79"; // 현우 App
            case 4: return "46181d98-613b-43b6-9585-eff76ca5c770"; // 수현 App
            case 5: return "92bd46a3-78f1-4979-b2ce-a39702dea496"; // 원종 App
            case 6: return "47c3ddeb-878b-4190-a962-31d66fb2a66c"; // 소현 App

            default: return "null";
        }
    }
}
