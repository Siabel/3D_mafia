using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class FindPassword : MonoBehaviour
{
    public TMP_InputField userIdInputField;
    public TMP_InputField userAnswerInputField;

    // Start is called before the first frame update
    void Start()
    {
    }

    // 버튼 클릭 시 호출될 함수
    public void PostPassword()
    {
        StartCoroutine(UnityWebRequestPassword());
    }

    IEnumerator UnityWebRequestPassword()
    {
        string url = "http://127.0.0.1:8000/password/";
        WWWForm form = new WWWForm();

        string id = userIdInputField.text;
        string answer = userAnswerInputField.text;
        form.AddField("user_id", id);
        form.AddField("user_answer", answer);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("찾기 성공: " + www.downloadHandler.text);

            // 찾기 성공 시, 비밀번호 팝업 창에 띄워 줌
        }
        else
        {
            Debug.Log("찾기 실패: " + www.error);
            Debug.Log("응답 본문: " + www.downloadHandler.text);

            // 찾기 살패 시, 실패 팝업 창 생성
        }
    }
}
