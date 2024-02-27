using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity=1;

    public GameObject handler;

    private Rigidbody2D rb;

    private Transform playerTransform;

    bool isClimbing, isLadder;
    bool isGrounded(){
        return GetComponent<Rigidbody2D>().velocity.y == 0;
    }

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode interactKey;

    Vector3 scale;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        handler=GameObject.FindGameObjectWithTag("GameController");
        gameObject.GetComponent<Rigidbody2D>().gravityScale=gravity;
        scale=playerTransform.localScale;
    }

    void Update(){
        move();
        climb();
    }
    
    void move(){
        float horizontalInput = 0f;
        if(isGrounded()){
            if (Input.GetKey(leftKey)){
                horizontalInput = -1f;
            }
            else if (Input.GetKey(rightKey)){
                horizontalInput = 1f;
            }
            if(horizontalInput!=0){
                transform.localScale = new Vector3(scale.x*horizontalInput, transform.localScale.y, transform.localScale.z);
            }
            Vector2 movement = new Vector2(horizontalInput, 0);
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

            // Jumping
            if(Input.GetKeyDown(jumpKey)){
                // print("s");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    void climb(){
        float verticalInput=0;
        if(isLadder){
            if(Input.GetKey(upKey)){
                verticalInput=1f;
            }else if(Input.GetKey(downKey)){
                verticalInput=-1f;
            }
            Vector2 movement = new Vector2(0, verticalInput);
            rb.velocity = new Vector2(rb.velocity.x, movement.y*moveSpeed);        
        }
        // isClimbing=false;
        // if(isLadder){
        //     print("isLadder");
        //     if(Input.GetKey(upKey)){
        //         isClimbing=true;
        //         verticalInput=1f;
        //         print("isUp");
        //     }else if(Input.GetKey(downKey)){
        //         isClimbing=true;
        //         verticalInput=-1f;
        //         print("isDown");
        //     }
        //     else  isClimbing = false;
        // }
        // if(isClimbing){
        //     Vector2 movement = new Vector2(0, verticalInput);
        //     rb.velocity = new Vector2(rb.velocity.x, movement.y*moveSpeed);
        //     print("isClimbing");
        // }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            gameObject.GetComponent<Rigidbody2D>().gravityScale=0;
            // climb();
            isLadder=true;
            // isClimbing=true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder=false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale=gravity;
            // isClimbing=false;
        }
    }
}
