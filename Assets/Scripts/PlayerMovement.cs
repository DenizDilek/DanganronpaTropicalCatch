using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D body;
    [SerializeField]private float speed;    
    private void Awake(){
        body = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,body.velocity.y);
        
        if(body.velocity.x>0 || body.velocity.x<0){
            if(body.velocity.x<0){
                gameObject.GetComponent<SpriteRenderer>().flipX = true ;
            }else{
                 gameObject.GetComponent<SpriteRenderer>().flipX = false ;
            }
            animator.SetBool("IsRunning",true);
            
        }else{
            animator.SetBool("IsRunning",false);
        }
    }
}
