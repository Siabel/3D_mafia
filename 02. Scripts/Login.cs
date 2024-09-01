using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField userIdInputField;
    public TMP_InputField userPasswordInputField;

    // Start is called before the first frame update
    void Start()
    {
    }

    // 버튼 클릭 시 호출될 함수
    public void PostLogin()
    {
        StartCoroutine(UnityWebRequestLogin());
    }

    IEnumerator UnityWebRequestLogin()
    {
        string url = "http://127.0.0.1:8000/login/";
        WWWForm form = new WWWForm();

        string id = userIdInputField.text;
        string password = userPasswordInputField.text;
        form.AddField("user_id", id);
        form.AddField("user_password", password);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        SceneManager.LoadScene("MenuScene");
        //if (www.result == UnityWebRequest.Result.Success)
        //{
        //    Debug.Log("로그인 성공: " + www.downloadHandler.text);

        //    // 로그인 성공 시, 다른 scene으로 이동
        //    // SceneManager.LoadScene("MenuScene");
        //}
        //else
        //{
        //    Debug.Log("로그인 실패: " + www.error);
        //    Debug.Log("응답 본문: " + www.downloadHandler.text);

        //    // 로그인 실패 시, 실패 팝업 띄움
        //}
    }
}
