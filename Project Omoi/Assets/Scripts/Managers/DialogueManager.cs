using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public bool isDialoguing = false, walkingDialogue = false;
    public Animator animator;
    public GameObject continueDialogueBtn;
    private Queue<string> sentences;
    private bool skipTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        continueDialogueBtn.SetActive(false);
    }

    void Update() {
        if (isDialoguing == true || walkingDialogue == true) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("SkipTyping is " + skipTyping);
                skipTyping = true;
            }
        }
    }

    public void StartDialogue(Dialogue dialogue, string cutsceneName) 
    {
        if (cutsceneName == "WalkingThoughts1" || cutsceneName == "WalkingThoughts2") {
            isDialoguing = false;
            walkingDialogue = true;
        } else {
            isDialoguing = true;
        }

        // Debug.Log("Starting Dialogue");
        animator.SetBool("IsOpen", true);
        continueDialogueBtn.SetActive(false);

        sentences.Clear();

        foreach (Dialogue.Cutscene cutscene in dialogue.cutscenes)
        {
            if (cutscene.sentences != null)
            {
                if (cutscene.name == cutsceneName)
                {
                    foreach (string sentence in cutscene.sentences)
                    {
                        sentences.Enqueue(sentence);
                    }
                }
            }
        }


        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        continueDialogueBtn.SetActive(false);
        skipTyping = false;
        
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        // Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue() 
    {
        // Debug.Log("End Dialogue");
        isDialoguing = false;
        walkingDialogue = false;
        animator.SetBool("IsOpen", false);
    }

    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        float timeToWait = 0.05f; // Time to wait between letters in seconds
        float timer = 0f;

        foreach(char letter in sentence.ToCharArray()) {
            if (skipTyping) {
                dialogueText.text += letter;
            } else {
                dialogueText.text += letter;
                while (timer < timeToWait) {
                    timer += Time.deltaTime; // Add Time.deltaTime to timer
                    yield return null; // Wait for 1 frame
                }
                timer = 0f; // Reset timer for the next letter
            }

        }

        continueDialogueBtn.SetActive(true);
    }

}
