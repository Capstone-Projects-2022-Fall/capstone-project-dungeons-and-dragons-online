using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public PhotonView photonView;
    //Hitbox for the player
    public Rigidbody2D rb;
    //The animation for the player
    public Animator anim;
    //The players individual camera
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    //Username
    public Text PlayerNameText;

    //This will be the players movement
    private Vector2 moveDirection;

    //Speed modifier
    public float moveSpeed;

    /// <summary>
    /// When a player is spawned, give them a camera and a username above there head
    /// </summary>
    private void Awake(){
        //If the camera is theirs
        if(photonView.IsMine){
            //Set it to their active camera
            PlayerCamera.SetActive(true);
            
            //Also set their name
            PlayerNameText.text = PhotonNetwork.NickName;
        } else {//If its not them
            //Give the other players their name
            PlayerNameText.text = photonView.Owner.NickName;
            
            //Give the other players a different color name to distinguish
            PlayerNameText.color = Color.cyan;
        }
    }

    /// <summary>
    /// Checks input from the user every frame
    /// </summary>
    private void Update(){
        //If there is an input from the current user
        if(photonView.IsMine){
            //Launch the check input function
            checkInput();
        }
    }
    /// <summary>
    /// Check input give the player the appropriate velocity based on the input from the user
    /// </summary>
    private void checkInput(){
        //Set x and y axis
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Set the direction
        moveDirection = new Vector2(moveX,moveY).normalized;
        //set inputs for animatior 
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetFloat("Speed", moveDirection.sqrMagnitude);

        //Get velocity based off of input
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

  
}
