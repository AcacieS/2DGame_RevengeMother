using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private float speed = 2f;
    private Vector3 direction;
    
    //getInput from player
    //apply movement to sprite
    //current position

    private void Update(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalInput, verticalInput).normalized;

        AnimateMovement(direction);
        
    }
    private void FixedUpdate(){
        this.transform.position += direction * speed * Time.deltaTime;
    }
    void AnimateMovement(Vector3 direction){
        //if the animator is set?
        if(animator != null){

            //if moving. magniture is 0 if no inpute
            if(direction.magnitude>0){
                animator.SetBool("isMoving", true);
                //know we know what is the horizontal and vertical?
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }else{
                animator.SetBool("isMoving", false);
            }
        }
    }

}
