using UnityEditor.Timeline;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private float maxTeleportDistance;
    [SerializeField] private GameObject indicatorPrefab;
    private CharacterController characterController;
    private GameObject indicator;
    private Vector3 ?position;
    private bool isAiming;

    private void Start() => characterController = GetComponent<CharacterController>();
    

    public void LocationIndicator()
    {
        RaycastHit hit;
        Transform origin = Camera.main.transform;
        if (Physics.Raycast(origin.position, origin.TransformDirection(Vector3.forward), out hit, maxTeleportDistance))
        {
            if (indicator == null)
            {
                indicator = Instantiate(indicatorPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, -hit.normal), transform);
            }
            UpdateIndicator(hit);
        }
        else
        {
            if (indicator != null)
            {
                indicator.SetActive(false);
                position = null;
            }
               
        }
    }

    public void Teleport()
    {
        if (!position.HasValue)
            return;
        
        indicator.SetActive(false);
        characterController.enabled = false;
        characterController.transform.position = position.Value;
        characterController.enabled = true;
    }

    public void UpdateIndicator(RaycastHit hit)
    {
        indicator.SetActive(true);
        indicator.transform.position = hit.point;
        indicator.transform.rotation = Quaternion.FromToRotation(Vector3.up, -hit.normal);
        position = hit.point;
    }
}
