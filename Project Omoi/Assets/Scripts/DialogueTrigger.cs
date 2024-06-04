using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(string dialogueSceneName) {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueSceneName);
    }

    public void ApproachingFlowerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, "Flower");
    }

    public void ApproachingTowerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, "Tower1");
    }

    public void WalkingDialogue1() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, "Tower1");
    }

    public void WalkingDialogue2() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, "Tower1");
    }

}
