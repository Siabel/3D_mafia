using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// public class ChannelManager : MonoBehaviour
public class ChannelManager : MonoBehaviourPunCallbacks
{
    public GameObject modalPanel; // ���� ������ ����� ��� ó���� ���� ����

    void Start()
    {
        modalPanel.SetActive(false); // ó���� ��� ��Ȱ��ȭ
    }
    public void ConnectToChannel(int channelNumber)
    {
        string appId = GetAppIdByChannel(channelNumber); // channelNumber�� �´� appId �Ҵ�

        // ���ο� AppSettings ��ü�� �����ϰ�, AppIdRealtime�� ����
        AppSettings settings = new AppSettings()
        {
            AppIdRealtime = appId,
        };

        PhotonNetwork.ConnectUsingSettings(settings); // ���� ���� ����
    }

    // ���� ���� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log($"���� ���� ����: {cause}"); // ���� ���� ���� �α�
        modalPanel.SetActive(true); // ���� ���������� ��� UI�� �����ش�.
    }

    public void ModalBtnClick() // ��ư Ŭ���ϸ� ��� ���ִ� ����
    {
        modalPanel.SetActive(false);
    }



    public void PlayerCounter() // �÷��̾� �� Ȯ���Լ�
    {
        int playerCount = PhotonNetwork.CountOfPlayersOnMaster; // ������ ������ �ִ� �÷��̾� ��, �κ� ����
        Debug.Log("���� �κ� �ִ� ���� ��: " + playerCount);
    }

    private string GetAppIdByChannel(int channelNumber) // channelNumber�� ������ AppId�� return
    {
        switch (channelNumber)
        {
            case 1: return "1bed5af5-423f-4e36-872f-365e84daed36"; // ���� App id PUN
            case 2: return "aa2de7f0-7461-498a-92c6-1b3c375c584f"; // ��ȣ App    
            case 3: return "d9302e11-06d7-49f0-8c92-ff23cec623c9"; // ���� App
            case 4: return "f794b165-4232-4fb2-80af-3b441256c86d"; // ���� App
            case 5: return "c8286018-b331-478d-a7ed-3749f12d7894"; // ���� App
            case 6: return "b55a1d31-ae4b-43af-95b6-a200413aa09a"; // ���� App

            default: return "null";
        }
    }

    private string GetChatAppIdByChannel(int channelNumber) // ���߿� ä�� ������ ��� �Ҵ��� Chat ���� AppId
    {
        // �� �޼���� ä�� ��ȣ�� ���� �ش��ϴ� AppId�� ��ȯ�ؾ� �մϴ�.
        switch (channelNumber)
        {
            case 1: return "�޾ƾ��Ѵ�"; // ���� App id Chat
            case 2: return "�޾ƾ��Ѵ�"; // ��ȣ App    
            case 3: return "27092388-5f9f-4aec-9f8b-83d65f965f79"; // ���� App
            case 4: return "46181d98-613b-43b6-9585-eff76ca5c770"; // ���� App
            case 5: return "92bd46a3-78f1-4979-b2ce-a39702dea496"; // ���� App
            case 6: return "47c3ddeb-878b-4190-a962-31d66fb2a66c"; // ���� App

            default: return "null";
        }
    }
}
