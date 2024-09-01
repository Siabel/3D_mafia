using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour, IInteractable
{
    private GameObject heldObject = null;

    public float throwForce = 600; // 오브젝트를 던질 때 적용할 힘

    public bool Interact(Interactor interactor)
    {
        if (heldObject == null)
        {
            // 오브젝트 선택 및 들기 로직
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 2f)) // 2 미터 내의 오브젝트 선택
            {
                ////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////
                // if (hit.collider.CompareTag("Rope")) // 로프 오브젝트 태그 확인
                // {   
                //     Debug.Log("로프");
                //     FixedJoint joint = hit.collider.GetComponent<FixedJoint>();
                //     if (joint != null)
                //     {
                //         // 여기에 로프 오브젝트의 연결 해제 로직을 추가하세요.
                //         // 예: joint.breakForce = 0.01f; // 로프를 즉시 끊습니다.
                //         Destroy(joint);
                //     }
                // }
                // else if (hit.collider.CompareTag("Pickup")) // 들 수 있는 오브젝트 태그 확인
                // {
                //     PickUpObject(hit.collider.gameObject);
                // }
                ////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////
                Debug.Log("테스트 오브젝트  들기");
                Debug.Log(hit.collider.gameObject + "----");
                PickUpObject(hit.collider.gameObject);

                return true;
            }
        }
        else
        {
            Debug.Log("테스트 오브젝트  던지기");
            // 오브젝트 던지기 로직
            ThrowHeldObject();
            
            return true;
        }

        return true;
    }

    private void PickUpObject(GameObject pickUpObject)
    {
        heldObject = pickUpObject;
        heldObject.transform.SetParent(transform); // 플레이어의 자식으로 설정
        heldObject.transform.localPosition = new Vector3(0, 0, 2); // 들고 있는 위치 조정
        heldObject.GetComponent<Rigidbody>().isKinematic = true; // 물리 연산 비활성화
    }

    private void ThrowHeldObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null); // 부모 관계 해제
        heldObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce); // 오브젝트 던지기
        heldObject = null; // 참조 초기화
    }
}
