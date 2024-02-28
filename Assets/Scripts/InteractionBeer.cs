using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBeer : MonoBehaviour
{
  public int coinss = 0;
  public int posBeer = 1;
  public GameObject beer;

  //interaction
  private int NUMBBEER = 2;
  private bool interactAllowed;
  private int numbCleanB=2;
  private int numbDirtyB=0;
  private int numbFullB=0;

  //number of
   private int coins = 0;
   private List<GameObject> currentCollisions = new List<GameObject> (1);
   private bool finishedAnimate=true;
   //public bool isHereM = false;
   //[SerializeField] private Text coinsText;
   
   private void Update(){
    if(interactAllowed && Input.GetKeyDown(KeyCode.E)){
      Interact();
    }
   }
  
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("CleanGlassMachine")||collision.gameObject.CompareTag("BeerMachine")||collision.gameObject.CompareTag("Table")){
      //currentCollisions[0]=collision.gameObject;
      currentCollisions.Add(collision.gameObject);
      interactAllowed = true;
    }
   }
   
   //OnTrigger (Collider2D)
   private void OnCollisionExit2D(Collision2D collision){
    if (collision.gameObject.CompareTag("CleanGlassMachine")||collision.gameObject.CompareTag("BeerMachine")||collision.gameObject.CompareTag("Table")){
      currentCollisions.Remove(collision.gameObject);
      interactAllowed = false;
    }
   }
   
   private void Interact(){
    //Cleaning Glass
    if (currentCollisions[0].CompareTag("CleanGlassMachine")){
      if(currentCollisions[0].GetComponent<Animator>().GetBool("isHereB")==false&&ActiveCleanMachine()){
         animationSet();
        }else{
          currentCollisions.Remove(currentCollisions[0]);
        }
    }
    //Beer Machine
    else if (currentCollisions[0].CompareTag("BeerMachine")){
      
        if(currentCollisions[0].GetComponent<Animator>().GetBool("isHereB")==false&&ActiveBeerMachine()){
          animationSet();
        }else{
          currentCollisions.Remove(currentCollisions[0]);
        }
    //Table
    }else{
      if(currentCollisions[0].GetComponent<Animator>().GetBool("isCustomerP")){
        if(currentCollisions[0].GetComponent<Animator>().GetBool("isHereB")==false&&ActiveTable()){
         animationSet();
        }else{
          currentCollisions.Remove(currentCollisions[0]);
        }
      }
    }   
      //coinsText.text = "Coins: " + coins;
   }
   private void animationSet(){
    currentCollisions[0].GetComponent<Animator>().SetBool("isHereB",true);
    currentCollisions[0].GetComponent<Animator>().SetInteger("posB",posBeer);
    beer.GetComponent<Animator>().SetBool("onHandBeer",false);
    currentCollisions[0].GetComponent<Animator>().SetBool("isActive",true);
   }
   private bool ActiveBeerMachine(){
        for(int i = 1; i<=NUMBBEER; i++){
          beer = GameObject.Find("/Player_Anna/Plateau/Beer"+i+"");
          if(beer.GetComponent<Animator>().GetBool("onHandBeer")&&beer.GetComponent<Animator>().GetInteger("stateBeer")==1){
            Debug.Log(i);
            posBeer=i;
            return true;
          }
        }
        return false; 
   }
   private bool ActiveCleanMachine(){
        for(int i = 1; i<=NUMBBEER; i++){
          beer = GameObject.Find("/Player_Anna/Plateau/Beer"+i+"");
          if(beer.GetComponent<Animator>().GetBool("onHandBeer")&&beer.GetComponent<Animator>().GetInteger("stateBeer")==0){
            Debug.Log(i);
            posBeer=i;
            return true;
          }
        }
        return false; 
   }
  private bool ActiveTable(){
    for(int i = 1; i<=NUMBBEER; i++){
          beer = GameObject.Find("/Player_Anna/Plateau/Beer"+i+"");
          if(beer.GetComponent<Animator>().GetBool("onHandBeer")&&beer.GetComponent<Animator>().GetInteger("stateBeer")==2){
            Debug.Log(i);
            posBeer=i;
            return true;
          }
        }
        return false; 
    }
}

//to check the list in
        /*foreach(GameObject gObject in currentCollisions){
          print(gObject.name);
        }*/