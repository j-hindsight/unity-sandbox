using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[System.Serializable]
public class NPC : MonoBehaviour
{
    public string[] dialogue;
    public string npcName;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            Interact();
        }
	}

    public void Interact()
    {
        DialogueManager.Instance.AddNewDialogue(dialogue, npcName);
    }
}
