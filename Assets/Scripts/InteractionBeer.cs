using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBeer : MonoBehaviour
{
  //interaction
  private bool interactAllowed;
  private bool animBeerM;
  private bool animCleanM;

  //number of
   private int coins = 0;
   private int numbBeer = 0;
   private int HaveGlassClean = 0;
   private int HaveGlassDirty = 0;
   private List<GameObject> currentCollisions = new List<GameObject> (1);
   //[SerializeField] private Text coinsText;
   private void Update(){
    if(interactAllowed && Input.GetKeyDown(KeyCode.E)){
      Interact();
    }
   }
  
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("CleanGlassMachine")){// && HaveGlassClean >= 1){
        interactAllowed = true;
        animCleanM = true;
      }

      if (collision.gameObject.CompareTag("BeerMachine")){// && HaveGlassClean >= 1){
        interactAllowed = true;
        animBeerM = true;

        currentCollisions.Add(collision.gameObject);
        //to check the list in
        /*foreach(GameObject gObject in currentCollisions){
          print(gObject.name);
        }*/
        //Debug.Log("BeerMachine enter");
      }

   }
   //OnTrigger (Collider2D)
   private void OnCollisionExit2D(Collision2D collision){
    if (collision.gameObject.CompareTag("BeerMachine")){
      Debug.Log("BeerMachine exit");
      interactAllowed = false;
      animBeerM = false;

      currentCollisions.Remove(collision.gameObject);
      /*foreach(GameObject gObject in currentCollisions){
          print(gObject.name);
        }*/
    }
   }
   private void Interact(){
       Debug.Log("got interact");
       if(animBeerM == true){
        Debug.Log(currentCollisions[0].name);
        currentCollisions[0].GetComponent<Animator>().enabled = true;
        //currentCollisions[0].GetComponent<Animator>().enabled = false;
        //need a time for numbBeer ++
        numbBeer++;
        HaveGlassClean--;
        //animation of it
        //coinsText.text = "Coins: " + coins;
       }
       if(animCleanM==true){
        Debug.Log("CleanGlassMachine");
        //need a time for numbBeer ++
        numbBeer++;
        HaveGlassClean--;
        //animation of it
        //coinsText.text = "Coins: " + coins;
       }
   }
}
