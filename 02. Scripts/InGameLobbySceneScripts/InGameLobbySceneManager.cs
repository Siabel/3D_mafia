using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameLobbySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform[] spown = GameObject.Find("Spowner").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, spown.Length);

        PhotonNetwork.Instantiate("Player", spown[idx].position, spown[idx].rotation, 0);        
    }

    public void ExitInGameLobbyRoom(){
        print("Ext In Game Lobby Csnene");
        SceneManager.LoadScene("LobbyScene");
        // PhotonNetwork.LoadLevel("LobbyScene");
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)){
            ExitInGameLobbyRoom();
        }
    }

}
