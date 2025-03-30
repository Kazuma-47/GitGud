using UnityEngine;

public class phaseAbility : Ability 
{
    [SerializeField] private float abilityRange;
    [SerializeField] private GameObject indicatorPrefab;
    [SerializeField] private Material newTexture;
    private GameObject indicator;
    private Vector3? position;
    private bool isAiming;
    RaycastHit hit;

    public override void OnActivate()
    {
        base.OnActivate();
        LocationIndicator();
    }

    public override void UseAbility()
    {
        PhaseObject();
        StartCoolDown();
    }

    public void LocationIndicator()
    {
        if (!abilityReady)
            return;
        Transform origin = Camera.main.transform;
        if (Physics.Raycast(origin.position, origin.TransformDirection(Vector3.forward), out hit, abilityRange))
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
            hit = new RaycastHit();
        }
    }
    public void PhaseObject()
    {
        if (!abilityReady)
            return;
        indicator.SetActive(false);
        if (hit.transform.CompareTag("PhasableObject"))
        {
            hit.transform.GetComponent<Collider>().isTrigger = true;
            hit.transform.GetComponent<Renderer>().material = newTexture;
        }
    }

    public void UpdateIndicator(RaycastHit hit)
    {
        indicator.SetActive(true);
        indicator.transform.position = hit.point;
        indicator.transform.rotation = Quaternion.FromToRotation(Vector3.up, -hit.normal);
        position = hit.point;
    }
}
