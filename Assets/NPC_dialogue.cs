using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index = 0;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject contButton;
    
    // Update is called once per frame
    void Start(){
        dialogueText.text="";
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            if(!dialoguePanel.activeInHierarchy){
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }else if(dialogueText.text==dialogue[index]){
                NextLine();
            }
        }
        if(dialogueText.text == dialogue[index]){
            contButton.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Q)&&dialoguePanel.activeInHierarchy){
            zeroText();
        }

        /*if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            if(dialoguePanel.activeInHierarchy){
                zeroText();
            }else{
                dialoguePanel.SetActive(true);
                if(Input.GetKeyDown(KeyCode.F)){
                    NextLine();
                }
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index]){
            contButton.SetActive(true);
        }*/
    }

    public void zeroText(){
        dialogueText.text="";
        index=0;
        dialoguePanel.SetActive(false);
    }
    IEnumerator Typing(){
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text+=letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine(){
        contButton.SetActive(false);
        if(index < dialogue.Length -1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }else{
            zeroText();
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("???");
        if(other.CompareTag("Player")){
            Debug.Log("heyyyy");
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
        }
    }
}
