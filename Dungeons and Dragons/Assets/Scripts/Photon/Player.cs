using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;
/// <summary>
/// This is the object for all users.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// The specific view for this object.
    /// </summary>
    public PhotonView photonView;
    /// <summary>
    /// Colider for this object.
    /// </summary>
    public Rigidbody2D rb;
    /// <summary>
    /// Animations for the player.
    /// </summary>
    public Animator anim;
    /// <summary>
    /// Users camera
    /// </summary>
    public GameObject PlayerCamera;
    /// <summary>
    /// Renderer
    /// </summary>
    public SpriteRenderer sr;
    /// <summary>
    /// Players username
    /// </summary>
    public Text PlayerNameText;
    /// <summary>
    /// The actual player
    /// </summary>
    public GameObject player;
    private Transform tr;
    /// <summary>
    /// Where the player can attack an enemy
    /// </summary>
    public GameObject attackArea;
    /// <summary>
    /// Wether they area attacking
    /// </summary>
    private bool attacking = false;
     /// <summary>
    /// Timer to end attack
    /// </summary>
    private float timeToAttack = 0.05f;
    private float timer = 0f;

    /// <summary>
    /// Direction the players moving.
    /// </summary>
    private Vector2 moveDirection;

     /// <summary>
    /// Speed at which they are moving.
    /// </summary>
    public float moveSpeed;
    // Start is called before the first frame update

    /// <summary>
    /// Character selector
    /// </summary>
    public CharacterDatabase characterDB;
    /// <summary>
    /// Renderer
    /// </summary>
    public SpriteRenderer artworkSprite;
    /// <summary>
    /// What character they have selected
    /// </summary>
    private int selectedOption = 0;

    /// <summary>
    /// Chat
    /// </summary>
    public static bool chatSelected;

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    public GameObject itemworld;

    private GameObject[] otherPlayers;

    public float arrowPower;// the power of the weapon

    //public GameObject bulletObject;
    //public Transform firePos;

    /// <summary>
    /// Detects if the chat is selected
    /// </summary>
    public void selectChat()
    {
        chatSelected = true;
    }

    /// <summary>
    /// Detects if the chat isn't selected
    /// </summary>
    public void deselectChat()
    {
        chatSelected = false;
    }

    /// <summary>
    /// Set the characters class and spawn them
    /// </summary>
    private void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();

    }
     /// <summary>
    /// When player spawns, turn on their camera and set their username.
    /// </summary>
    private void Awake(){
        if (photonView.IsMine){
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.NickName;
            //Player picks class
            //ExitGames.Client.Photon.Hashtable PlayerProps = new ExitGames.Client.Photon.Hashtable();
            //PlayerProps.Add("Class", whatever class they chose);
            //Player.SetCustomProperties(PlayerProps);

        } else {
            //class = photonView.GetCustomProperty("Class");
            //sprite = class;
            PlayerNameText.text = photonView.Owner.NickName;
            PlayerNameText.color = Color.cyan;
        }
        
            inventory = new Inventory();
            // uiInventory.setInventory(inventory);
            // ItemWorld.SpawnItemWorld(new Vector3 (1, 1), new Item {itemType = Item.ItemType.LongSword, amt = 1});
            // ItemWorld.SpawnItemWorld(new Vector3 (-1, 1), new Item {itemType = Item.ItemType.HPot, amt = 1});
            // ItemWorld.SpawnItemWorld(new Vector3 (0, -1), new Item {itemType = Item.ItemType.RPot, amt = 1});
            // ItemWorld.SpawnItemWorld(new Vector3((float)0.98,(float)-0.46, 0), new Item{itemType = Item.ItemType.HPot, amt = 1});
    }
    /// <summary>   
    /// Checks if player is moving their character and moves them appropriately.
    /// </summary>
    private void Update(){
        if(photonView.IsMine && !chatSelected && !UIPause.isPaused && !UIPause.isAI){
            checkInput();
        } else if (photonView.IsMine && UIPause.isAI){
            moveTowardsPlayer();
        }
    }
    /// <summary>
    /// Detects if a player is attacking.
    /// </summary>
    public void FixedUpdate()
    {
        if (photonView.IsMine && !chatSelected && !UIPause.isPaused && !UIPause.isAI)
        {
            if (Input.GetKeyDown(KeyCode.J) && sr.sprite.name == "skinSelection_2" || Input.GetKeyDown(KeyCode.J) && sr.sprite.name == "skinSelection_0")
            {
                photonView.RPC("Attack", RpcTarget.AllBuffered);
            }
            if (Input.GetMouseButtonDown(0) && sr.sprite.name == "skinSelection_1")
            {
                float force = moveDirection.x < 0 ? -arrowPower : arrowPower;
                float _offset = moveDirection.x < 0 ? -0.1f : 0.1f;
                Vector3 offset = new Vector3(_offset, 0, 0);
                GameObject arrowObj = PhotonNetwork.Instantiate("PhotonArrow", tr.position + offset, Quaternion.identity);
                Rigidbody2D arb = arrowObj.GetComponent<Rigidbody2D>();
                SpriteRenderer _spr = arrowObj.GetComponent<SpriteRenderer>();
                _spr.flipX = _offset < 0;
                arb.AddForce(new Vector2(force, 0));
            }
        }
        Move();
    }
    /// <summary>
    /// Check what button they are clicking and set the animation accordingly.
    /// </summary>
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
    /// <summary>
    /// Moves the character based on input.
    /// </summary>
    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (moveDirection.x < 0)
        {
            //sr.flipX = true;//when go to leftside, flip x of renderer
            photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
                //FlipFalse();
        }
        if (moveDirection.x > 0)
        {
            //sr.flipX = false;//when go to rightside, flip x of renderer
            photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
                //FlipTrue();
        }

        
        //checkFlipping();
        //Debug.Log("here");
        //Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
    }

    [PunRPC]
    /// <summary>
    /// Handles the players actually dealing damage to enemies.
    /// </summary>
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

    /*
    private void Shoot()
    {
        if (sr.flipX = false)
        {
            GameObject obj = PhotonNetwork.Instantiate(bulletObject.name, new Vector2(firePos.position.x, firePos.position.y), Quaternion.identity, 0);
        }

        if (sr.flipX = true)
        {
            GameObject obj = PhotonNetwork.Instantiate(bulletObject.name, new Vector2(firePos.position.x, firePos.position.y), Quaternion.identity, 0);
            obj.GetComponent<PhotonView>().RPC("ChangeDir_left", RpcTarget.AllBuffered);
        }
    }
    */
    /// <summary>
    /// Handles the players animation and which way it is facing.
    /// </summary>
    [PunRPC]
    void FlipFalse()
    {
        //attackArea.transform.position = new Vector3(attackArea.transform.position.x - 0.29f, attackArea.transform.position.y, 0);
        player.transform.localScale = new Vector3(-0.5f, player.transform.localScale.y,1);
    }
    
     /// <summary>
    /// Handles the players animation and which way it is facing.
    /// </summary>
    [PunRPC]
    void FlipTrue()
    {
        //attackArea.transform.position = new Vector3(attackArea.transform.position.x, attackArea.transform.position.y, 0);
        player.transform.localScale = new Vector3(0.5f, player.transform.localScale.y,1);
    }

     /// <summary>
    /// Sets the players selected class.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.addItem(itemWorld.getItem());
            itemWorld.destroyItem();
        }

        if (collider.GetComponent<SpriteRenderer>() != null && collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_0" && collider.gameObject.tag != "Player")
        {
            Character character = characterDB.GetCharacter(0);
            sr.sprite = character.CharacterSprtie;
        }

        if (collider.GetComponent<SpriteRenderer>() != null && collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_1" && collider.gameObject.tag != "Player")
        {
            Character character = characterDB.GetCharacter(1);
            sr.sprite = character.CharacterSprtie;
        }

        if (collider.GetComponent<SpriteRenderer>() != null && collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_2" && collider.gameObject.tag != "Player")
        {
            Character character = characterDB.GetCharacter(2);
            sr.sprite = character.CharacterSprtie;
        }
    }

    private void moveTowardsPlayer()
    {
        otherPlayers = GameObject.FindGameObjectsWithTag("Player");
        
        for (int i = 0; i < otherPlayers.Length; i++)
        {
            float tempx = otherPlayers[i].transform.position.x-transform.position.x;
            float tempy = otherPlayers[i].transform.position.y-transform.position.y;
            if (tempx>0.2 || tempx < -0.2 || tempy < -0.2 || tempy > 0.2) {
                Debug.Log("x" + tempx);
                Debug.Log("y" + tempy);
                transform.position = Vector2.MoveTowards(transform.position, otherPlayers[i].transform.position, moveSpeed * Time.deltaTime);
            }
            
        }
    }

}