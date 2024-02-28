using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_end_animation : MonoBehaviour
{
    //public;
    public InteractionBeer InteractB;
    public GameObject beer;

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
                //Console.Log(anim.Get)
                beer = GameObject.Find("/Player_Anna/Plateau/Beer"+anim.GetInteger("posB")+"");
                beer.GetComponent<Animator>().SetBool("isFAnimate",true);
                if(tag=="BeerMachine"){
                    Debug.Log("where is the first");
                    Debug.Log(InteractB.posBeer);
                    beer.GetComponent<Animator>().SetInteger("stateBeer",2);
                }else if(tag=="CleanGlassMachine"){
                    beer.GetComponent<Animator>().SetInteger("stateBeer",1);
                }else{
                    beer.GetComponent<Animator>().SetInteger("stateBeer",0);
                    anim.SetBool("isCustomerP", false);
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
        InteractB.coinss++;
        Debug.Log(InteractB.coinss);
        
    }
}
