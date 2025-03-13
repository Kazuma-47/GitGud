using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class StorageRoomLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private UnityEvent onFinished;
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private GameObject lastDoor;
    private int currentPoint;

    public void AddPoint()
    {
        currentPoint++;
        objectiveText.text = currentPoint.ToString() + " / " + points.Length.ToString() + " Cubes";
        checkIfFinshed();
    }

    public void checkIfFinshed()
    {
        if (currentPoint >= points.Length)
        {
            lastDoor.SetActive(false);
            onFinished?.Invoke();
        }
    }
}
