using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class DisplayDialogue : MonoBehaviour
{
    [SerializeField] private string[] DialogueLines;
    [SerializeField] private TextMeshProUGUI DialogueBox;
    [SerializeField] private float linePauseDuration = 3f;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private bool playFirstLineOnStart;

    private int currentLine;
    private Coroutine typingCoroutine;
    private Coroutine multipleLinesCoroutine;
    private Queue<string> customLinesQueue = new Queue<string>();
    private bool isTyping = false;

    private void Start()
    {
        if (playFirstLineOnStart)
        {
            DialogueBox.gameObject.SetActive(true);
            PlayLine(null);
        }
    }

    public void NextLine()
    {
        currentLine++;
        PlayLine(null);
    }

    public void PlayMultipleLines(string line)
    {
        DialogueBox.gameObject.SetActive(true);
        customLinesQueue.Enqueue(line);

        if (!isTyping)
        {
            multipleLinesCoroutine = StartCoroutine(ProcessLines());
        }
    }

    public void PlayLine(string? line)
    {
        DialogueBox.gameObject.SetActive(true);
        if (typingCoroutine != null) 
            StopCoroutine(typingCoroutine);
       
        if(multipleLinesCoroutine != null)
            StopCoroutine(multipleLinesCoroutine);

        ClearText();
        if (line == null)
            typingCoroutine = StartCoroutine(TypeOneLine(DialogueLines[currentLine]));
        else 
            typingCoroutine = StartCoroutine(TypeOneLine(line));
    }

    private IEnumerator ProcessLines()
    {
        while (customLinesQueue.Count > 0)
        {
            isTyping = true; 

            string currentLine = customLinesQueue.Dequeue(); 
            DialogueBox.gameObject.SetActive(true);

            DialogueBox.text = ""; 
            foreach (char c in currentLine)
            {
                DialogueBox.text += c;
                yield return new WaitForSeconds(typingSpeed); 
            }

            yield return new WaitForSeconds(linePauseDuration);
        }

        isTyping = false; 
        DialogueBox.gameObject.SetActive(false); 
    }

    private IEnumerator TypeOneLine(string line)
    {
        DialogueBox.text = ""; 
        foreach (char c in line)
        {
            DialogueBox.text += c; 
            yield return new WaitForSeconds(typingSpeed); 
        }
        yield return new WaitForSeconds(linePauseDuration);
        DialogueBox.gameObject.SetActive(false);
    }

    private void ClearText() => DialogueBox.text = "";
}

