// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class DialogueManager : MonoBehaviour
// {
//     public TextMeshProUGUI dialogueText;

//     public Animator animator;
//     public GameObject continueDialogueBtn;
//     private Queue<string> sentences;

//     // Start is called before the first frame update
//     void Start()
//     {
//         sentences = new Queue<string>();
//         continueDialogueBtn.SetActive(false);
//     }

//     public void StartDialogue(Dialogue dialogue) 
//     {
//         // Debug.Log("Starting Dialogue");
//         animator.SetBool("IsOpen", true);
//         continueDialogueBtn.SetActive(false);

//         sentences.Clear();
//         // foreach (string sentence in dialogue.sentences) {
//         //     sentences.Enqueue(sentence);
//         // }

//         foreach (Dialogue.Cutscene cutscene in dialogue.cutscenes)
//         {
//             for (int i = 0; i < cutscene.sentences.Length; i++)
//             {
//                 sentences.Enqueue(cutscene.sentences[i]);
//             }
//         }


//         DisplayNextSentence();
//     }

//     public void DisplayNextSentence() 
//     {
//         continueDialogueBtn.SetActive(false);
        
//         if(sentences.Count == 0) {
//             EndDialogue();
//             return;
//         }

//         string sentence = sentences.Dequeue();
//         // Debug.Log(sentence);
//         StopAllCoroutines();
//         StartCoroutine(TypeSentence(sentence));
//     }

//     void EndDialogue() 
//     {
//         // Debug.Log("End Dialogue");
//         animator.SetBool("IsOpen", false);
//     }

//     IEnumerator TypeSentence(string sentence) 
//     {
//         dialogueText.text = "";
//         float timeToWait = 0.05f; // Time to wait between letters in seconds
//         float timer = 0f;

//         foreach(char letter in sentence.ToCharArray()) {
//             dialogueText.text += letter;
//             while (timer < timeToWait) {
//                 timer += Time.deltaTime; // Add Time.deltaTime to timer
//                 yield return null; // Wait for 1 frame
//             }
//             timer = 0f; // Reset timer for the next letter
//         }

//         continueDialogueBtn.SetActive(true);
//     }

// }
