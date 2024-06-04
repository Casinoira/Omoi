using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Player") {
            switch (gameObject.name)
            {
                case "FlowerTrigger":
                    dialogueTrigger.TriggerDialogue("Flower");
                    // Debug.Log("Player entered the flower trigger!");
                    break;
                    
                case "Tower1Trigger":
                    dialogueTrigger.TriggerDialogue("Tower1");
                    // Debug.Log("Player entered the tower 1 trigger!");
                    break;

                case "Tower2Trigger":
                    dialogueTrigger.TriggerDialogue("Tower2");
                    // Debug.Log("Player entered the tower 2 trigger!");
                    break;

                case "AltarTrigger":
                    dialogueTrigger.TriggerDialogue("Altar");
                    // Debug.Log("Player entered the altar trigger!");
                    break;

                case "Walking1Trigger":
                    dialogueTrigger.TriggerDialogue("WalkingThoughts1");
                    // Debug.Log("Player entered the altar trigger!");
                    break;

                case "Walking2Trigger":
                    dialogueTrigger.TriggerDialogue("WalkingThoughts2");
                    // Debug.Log("Player entered the altar trigger!");
                    break;

                default:

                    break;
            }

            gameObject.SetActive(false);
        }
    }

}
