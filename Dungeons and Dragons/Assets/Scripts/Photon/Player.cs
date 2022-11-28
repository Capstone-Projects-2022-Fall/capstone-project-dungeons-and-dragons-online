using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Player : MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public Text PlayerNameText;
    public GameObject player;
    public CharacterDatabase characterDB;

    //attack
    public GameObject attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.05f;
    private float timer = 0f;

    private Vector2 moveDirection;

    public float moveSpeed;

    private void Awake(){

        if (photonView.IsMine){
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.NickName;
           
        }
        else {
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
            if (Input.GetKeyDown(KeyCode.J) && sr.sprite.name == "skinSelection_0" || Input.GetKeyDown(KeyCode.J) && sr.sprite.name == "skinSelection_2")
            {
                photonView.RPC("Attack", RpcTarget.AllBuffered);
            }

            if (Input.GetMouseButtonDown(0) && Input.GetKeyDown(KeyCode.J) && sr.sprite.name == "skinSelection_1")
            {
                //Code to do
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
        //Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
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
        player.transform.localScale = new Vector3(-0.5f, player.transform.localScale.y,1);
    }
    
    [PunRPC]
    void FlipTrue()
    {
        //attackArea.transform.position = new Vector3(attackArea.transform.position.x, attackArea.transform.position.y, 0);
        player.transform.localScale = new Vector3(0.5f, player.transform.localScale.y,1);
    }
    /*
    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        sr.sprite = character.CharacterSprtie;
    }
    */

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If the target has EnemyHealth compnent then is triggered
        if (collider.GetComponent<SpriteRenderer>() != null && collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_0")
        {
            Character character = characterDB.GetCharacter(0);
            sr.sprite = character.CharacterSprtie;
        }

        if (collider.GetComponent<SpriteRenderer>() != null && collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_1")
        {
            Character character = characterDB.GetCharacter(1);
            sr.sprite = character.CharacterSprtie;
        }

        if (collider.GetComponent<SpriteRenderer>() != null && collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_2")
        {
            Character character = characterDB.GetCharacter(2);
            sr.sprite = character.CharacterSprtie;
        }

    }
}
