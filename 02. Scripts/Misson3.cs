using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misson : MonoBehaviour
{
    private string objectTag; // 물체의 태그
    public float detectionRadius = 5f; // 감지 반경
    public Color highlightColor = Color.yellow; // 감지 반경 내에 있는 물체의 색상

    private Renderer objectRenderer; // 물체의 랜더러
    private Color originalColor; // 물체의 원래 색상

    private void Start()
    {
        detectionRadius = 2f; // 감지 반경
        objectRenderer = GetComponent<Renderer>(); // 물체의 랜더러 가져오기

        // 물체의 초기 색상 저장
        originalColor = objectRenderer.material.color;
    }

    private void Update()
    {
        SetMission();
    }

    // 미션 코드
    // private void ThrowOfficeSuppliesMission()
    // {

    // }


    // 미션 초기 코드
    private void SetMission() {
        // 주어진 태그로 플레이어를 찾음
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // 플레이어를 찾았을 때만 실행
        // ** 추후에 이 부분에 playerObject 가 해당 물체의 미션을 가지고 있는지 확인하는 코드가 필요하다. **
        // ** playerObject 의 mission child 의 리스트와 해당 물체의 태그(objectTag 로 변수 지정되어있음)를 비교하는 로직을 추가한다. **
        if (playerObject != null)
        {
            // 플레이어와 이 객체 간의 거리를 계산
            float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

            // 거리가 감지 반경보다 짧으면 플레이어가 인식 반경 안에 있음
            if (distanceToPlayer <= detectionRadius)
            {
                Debug.Log("Player detected!"); // 플레이어가 감지됨을 로그로 출력

                // 인식 반경 내에 있는 물체를 하이라이트하기
                HighlightObject();
                // ThrowOfficeSuppliesMission();
            }
            else
            {
                // 인식 반경 내에 없는 경우 원래 색상으로 되돌리기
                ResetHighlight();
            }
        }
    }

    // 미션 초기 코드 + 인식 반경 내에 있는 물체를 하이라이트하는 함수
    private void HighlightObject()
    {
        // 물체의 랜더러가 있을 경우에만 실행
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor; // 물체의 색상 변경
        }
    }

    // 미션 초기 코드 + 물체의 원래 색상으로 되돌리는 함수
    private void ResetHighlight()
    {
        // 물체의 랜더러가 있을 경우에만 실행
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; // 물체의 색상을 원래 색상으로 변경
        }
    }
}
