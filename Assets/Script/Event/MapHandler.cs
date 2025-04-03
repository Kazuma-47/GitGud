using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] MapPhases;
    private int currentPhase;

    public void NextPhase()
    {
        currentPhase++;
        foreach (GameObject phase in MapPhases)
        {
            phase.SetActive(false);
        }
        MapPhases[currentPhase].gameObject.SetActive(true);
    }
}
