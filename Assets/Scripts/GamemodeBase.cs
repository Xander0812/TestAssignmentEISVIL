using UnityEngine;
using UnityEngine.EventSystems;

public class GamemodeBase : MonoBehaviour
{
    public float rayLength;
    public LayerMask targetLayer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray, out _hit, rayLength, targetLayer))
            {
                _hit.collider.GetComponent<InteractiveObject>().DestroySelf();
                //Debug.Log(_hit.collider.gameObject.name);
            }
        }
    }
}
