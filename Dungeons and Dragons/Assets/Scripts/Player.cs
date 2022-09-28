using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public Text PlayerNameText;

    private Vector2 moveDirection;

    public float moveSpeed;
    // Start is called before the first frame update
    private void Awake(){
        if(photonView.isMine){
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;
        } else {
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.cyan;
        }
    }

    private void Update(){
        if(photonView.isMine){
            checkInput();
        }
    }

    private void checkInput(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY).normalized;

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Debug.Log("here");
    }

  
}
