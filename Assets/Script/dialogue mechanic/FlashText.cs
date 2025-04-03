using System.Collections;
using UnityEngine;
using TMPro;

public class FlashText : MonoBehaviour
{
    [SerializeField] private GameObject UIelement;
    [SerializeField] private TextMeshProUGUI textElement;
    [SerializeField] private float flashInterval = 0.5f; 
    [SerializeField] private string[] textOptions;

    private int currentTextIndex = 0; 
    private Coroutine flashCoroutine;
    public void StartFlashing()
    {
        if (flashCoroutine == null)
        {
            flashCoroutine = StartCoroutine(Flash());
        }
    }

    public void StopFlashing()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            flashCoroutine = null;
            UIelement.SetActive(true); 
        }
    }

    private IEnumerator Flash()
    {
        while (currentTextIndex < textOptions.Length)
        {
            UIelement.SetActive(!UIelement.activeSelf);

            if (UIelement.activeSelf)
            {
                textElement.text = textOptions[currentTextIndex];
                currentTextIndex++;
            }

            yield return new WaitForSeconds(flashInterval);
        }

        UIelement.SetActive(false);
        flashCoroutine = null;
    }
}
