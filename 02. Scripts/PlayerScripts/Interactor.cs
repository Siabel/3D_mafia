using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
     // 물체 상호작용 할당
    [Header("Interaction Variable")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 1.2f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private int numFound;
    private readonly Collider[] colliders = new Collider[3];

    // 물체 상호작용 활성화 할당
    [Header("Object Highlight")]
    [SerializeField] private Highlight[] highlight;

    // 상호작용 인터페이스 할당
    private IInteractable interactable;

    public void Interaction()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, 
            interactionPointRadius, colliders, interactableMask);

        // 앞에 물체가 있다면,
        if(numFound > 0)
        {   
            // 충돌한 물체의 오브젝트를 가지고 온다.
            Transform obj = colliders[0].transform;
            // 충돌한 물체의 인터페이스 IIneractable 를 가지고 온다.
            interactable = colliders[0].GetComponent<IInteractable>();

            // 앞에 물체가 있다면,
            if(interactable != null)
            {   
                // 하이라이트가 켜져있지 않다면,
                for(int i = 0; i < highlight.Length; i++)
                {
                    // 충돌한 물체와 하이라이브 물체를 매핑하고,
                    if(highlight[i].name == obj.GetChild(0).name)
                    {
                        // 하이라이트가 꺼져있다면,
                        if(!highlight[i].IsDisplayed)
                        {
                            // 하이라이트를 킨다.
                            highlight[i].Setup();
                        }
                        // 왼쪽 마우스 클릭 한다면,
                        if(Input.GetMouseButton(0))
                        {
                            // 해당 물체를 작용시킨다.
                            Debug.Log(this + "ttthishhisss");
                            interactable.Interact(this);
                        }
                    }
                }
            }
        }
        // 앞에 아무런 물체가 없다면,
        else
        {
            // 앞에 물체가 있다면,
            if(interactable != null)
            {
                interactable = null;
            }
            // 하이라이트를 끈다.
            for(int i = 0; i < highlight.Length; i++)
            {
                if(highlight[i].IsDisplayed)
                {
                    highlight[i].Setdown();
                }
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);    
    }
}
