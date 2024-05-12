using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonT : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject customersPanel;
    public bool isTutorialPanel=true;
    private void Update(){

        if(Input.GetKeyDown(KeyCode.E)&&isTutorialPanel==true){
            isTutorialPanel=false;
            customersPanel.SetActive(true);
            tutorialPanel.SetActive(false);
        }
    }
}
