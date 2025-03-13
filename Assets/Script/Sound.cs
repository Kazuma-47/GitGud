using UnityEngine;

[CreateAssetMenu(menuName = "Sound", fileName = "Audio")] 
public class Sound : ScriptableObject
{
    public string AudioName;
    public AudioClip AudioClip;
}
