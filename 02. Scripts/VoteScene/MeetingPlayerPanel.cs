using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetingPlayerPanel : MonoBehaviour
{
    // ĳ���� �̹��� �� ����
    [SerializeField]
    private Image characterImg;

    // �г��� ǥ��
    [SerializeField]
    private Text nicknameText;

    // ���� ĳ����
    [SerializeField]
    private GameObject deadPlayerBlock;

    // �Ű��� ǥ��
    [SerializeField]
    private GameObject reportSign;

    // � player�� panel���� ����
    public IngameCharacterMover targetPlayer;

    public void SetPlayer(CharacterController target)
    {
        Material inst = Instantiate(characterImg.material);
        characterImg.material = inst;

        targetPlayer = target;
        characterImg.material.SetColor("_PlayerColor", PlayerColor.GetColor(targetPlayer.playerColor));
        nicknameText.text = target.nickname;

        // ���Ǿư� �� �� �ٸ� ���Ǿ� �̸� ������ �����
        var myCharacter = GameRoomPlayer.myRoomPlayer.myCharacter as IngameCharacterMover;
        if((myCharacter.playerType & EplayerType.Mafia) == EPlayerType.Mafia)
            && ((targetPlayer.playerType & EPlayerType.Mafia) == EPlayerType.Mafia))
        {
            nicknameText.color = Color.red;
        }

        // panel player�� �׾��ٸ� ȸ�� panel �ѱ�
        deadPlayerBlock.SetActive((targetPlayer.playerType & EPlayerType.Ghost) == EplayerType.Ghost);

        // �Ű��ڶ�� �Ű��ư Ȱ��ȭ
        reportSign.SetActive();
    }
}
