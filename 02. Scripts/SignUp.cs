using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class SignUp : MonoBehaviour
{
    public TMP_InputField userNameInputField;
    public TMP_InputField userIdInputField;
    public TMP_InputField userPasswordInputField;
    public TMP_InputField userAnswerInputField;


    // Start is called before the first frame update
    void Start()
    {
    }

    // 버튼 클릭 시 호출될 함수
    public void PostSignUp()
    {
        StartCoroutine(UnityWebRequestSignUp());
    }

    IEnumerator UnityWebRequestSignUp()
    {
        string url = "http://127.0.0.1:8000/sign/";
        WWWForm form = new WWWForm();

        string name = userNameInputField.text;
        string id = userIdInputField.text;
        string password = userPasswordInputField.text;
        string answer = userAnswerInputField.text;

        form.AddField("user_name", name);
        form.AddField("user_id", id);
        form.AddField("user_password", password);
        form.AddField("user_answer", answer);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("회원가입 성공: " + www.downloadHandler.text);

            // 찾기 성공 시, 성공 팝업 창 생성
        }
        else
        {
            Debug.Log("회원가입 실패: " + www.error);
            Debug.Log("응답 본문: " + www.downloadHandler.text);

            // 찾기 살패 시, 실패 팝업 창 생성
        }
    }
}
