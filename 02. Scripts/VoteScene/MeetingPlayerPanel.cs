using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetingPlayerPanel : MonoBehaviour
{
    // 캐릭터 이미지 색 변경
    [SerializeField]
    private Image characterImg;

    // 닉네임 표시
    [SerializeField]
    private Text nicknameText;

    // 죽은 캐릭터
    [SerializeField]
    private GameObject deadPlayerBlock;

    // 신고자 표시
    [SerializeField]
    private GameObject reportSign;

    // 어떤 player의 panel인지 구분
    public IngameCharacterMover targetPlayer;

    public void SetPlayer(CharacterController target)
    {
        Material inst = Instantiate(characterImg.material);
        characterImg.material = inst;

        targetPlayer = target;
        characterImg.material.SetColor("_PlayerColor", PlayerColor.GetColor(targetPlayer.playerColor));
        nicknameText.text = target.nickname;

        // 마피아가 볼 때 다른 마피아 이름 빨갛게 만들기
        var myCharacter = GameRoomPlayer.myRoomPlayer.myCharacter as IngameCharacterMover;
        if((myCharacter.playerType & EplayerType.Mafia) == EPlayerType.Mafia)
            && ((targetPlayer.playerType & EPlayerType.Mafia) == EPlayerType.Mafia))
        {
            nicknameText.color = Color.red;
        }

        // panel player가 죽었다면 회색 panel 켜기
        deadPlayerBlock.SetActive((targetPlayer.playerType & EPlayerType.Ghost) == EplayerType.Ghost);

        // 신고자라면 신고버튼 활성화
        reportSign.SetActive();
    }
}
