using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public Text PlayerNameText;
    public GameObject player;

    //attack
    public GameObject attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.05f;
    private float timer = 0f;

    private Vector2 moveDirection;

    public float moveSpeed;
    // Start is called before the first frame update
    private void Awake(){
        if (photonView.IsMine){
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.NickName;
            
        } else {
            PlayerNameText.text = photonView.Owner.NickName;
            PlayerNameText.color = Color.cyan;
        }
    }

    private void Update(){
        if(photonView.IsMine){
            checkInput();
        }
    }

    public void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                photonView.RPC("Attack", RpcTarget.AllBuffered);
            }
        }
        Move();
    }

    private void checkInput()
    {
        //move direction
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;



        //set inputs for animatior 
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetFloat("Speed", moveDirection.sqrMagnitude);

    }
    /*
    public void Attack(bool attacking)
    {
        attackArea.SetActive(attacking);
    }*/

    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (moveDirection.x < 0)
        {
                photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
                //FlipFalse();
        }
        if (moveDirection.x > 0)
        {
                photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
                //FlipTrue();
        }

        
        //checkFlipping();
        //Debug.Log("here");
    }

    [PunRPC]
    void Attack()
    {

        // Key J for normal attack the attack status will become ture
        attacking = true;
        attackArea.SetActive(attacking);
        
        // Attack status is true then will call the attackArea class to start attacking
        if (attacking)
        {
            timer += Time.deltaTime * 2;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
        
    }

    [PunRPC]
    void FlipFalse()
    {
        //attackArea.transform.position = new Vector3(attackArea.transform.position.x - 0.29f, attackArea.transform.position.y, 0);
        player.transform.localScale = new Vector3(-1.01715f, player.transform.localScale.y,1);
    }
    
    [PunRPC]
    void FlipTrue()
    {
        //attackArea.transform.position = new Vector3(attackArea.transform.position.x, attackArea.transform.position.y, 0);
        player.transform.localScale = new Vector3(1.01715f, player.transform.localScale.y,1);
    }

}
