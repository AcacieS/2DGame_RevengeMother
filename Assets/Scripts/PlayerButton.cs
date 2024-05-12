using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject tutorialPanel;
    public GameObject ButtonT;
    private bool isStartPanel=true;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)&&isStartPanel==true){
            StartPanel.SetActive(false);
            tutorialPanel.SetActive(true);
            ButtonT.SetActive(true);
            isStartPanel=false;
        }
    }
}
