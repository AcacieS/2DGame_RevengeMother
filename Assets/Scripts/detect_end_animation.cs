using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detect_end_animation : MonoBehaviour
{
    //public;
    public GameObject customerPanel;
    public Text CustomersText;
    public InteractionBeer InteractB;
    public GameObject beer;
    public GameObject tables;

    //private
    public bool isFinished;
    private bool isPlayer = false;
    private Animator anim;
    private void Start(){
        anim = GetComponent<Animator>();
    }
    private void Update(){
    
        if(GetComponent<Animator>().GetBool("isFinishedB")){
            if(Input.GetKeyDown(KeyCode.F)&&isPlayer){
                beer = GameObject.Find("/Player_Marianne/Plateau/Beer"+anim.GetInteger("posB")+"");
                beer.GetComponent<Animator>().SetBool("isFAnimate",true);
                if(tag=="BeerMachine"){
                    Debug.Log("where is the first");
                    Debug.Log(InteractB.posBeer);
                    beer.GetComponent<Animator>().SetInteger("stateBeer",2);
                }else if(tag=="CleanGlassMachine"){
                    beer.GetComponent<Animator>().SetInteger("stateBeer",1);
                }else{
                    InteractB.customers--;
                    CustomersText.text = "Customers left: " + InteractB.customers;
                    anim.SetBool("animCustF", false);
                    beer.GetComponent<Animator>().SetInteger("stateBeer",0);
                    anim.SetBool("isCustomerP", false);
                    tables = GameObject.Find("Tables");

                    int numbAvailable = tables.GetComponent<Animator>().GetInteger("availableTable");
                    tables.GetComponent<Animator>().SetInteger("availableTable",numbAvailable+1);
                    if(InteractB.customers<=0){
                        customerPanel.SetActive(false);
                        InteractB.EndPanel.SetActive(true);
                    }
                }
                beer.GetComponent<Animator>().SetBool("onHandBeer",true);
                anim.SetInteger("posB",0);
                anim.SetBool("isActive",false);
                anim.SetBool("isHereB",false);
                anim.SetBool("isFinishedB", false);
                
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Player")){
      isPlayer=true;
    }
   }
   private void OnCollisionExit2D(Collision2D collision)
   {
      isPlayer=false;
   }
    public void finishedAnimate(){
        anim.SetBool("isFinishedB", true); 
    }
    public void finishedCustomerAnim(){
        anim.SetBool("animCustF", true);
    }
}
