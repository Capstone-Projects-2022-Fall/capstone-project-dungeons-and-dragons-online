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
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
        
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
        
            // inventory = new Inventory();
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
        if(photonView.IsMine && !chatSelected){
            checkInput();
        }
    }
    /// <summary>
    /// Detects if a player is attacking.
    /// </summary>
    public void FixedUpdate()
    {
        if (photonView.IsMine && !chatSelected)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                photonView.RPC("Attack", RpcTarget.AllBuffered);
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
    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprtie;
    }

    /// <summary>
    /// Sets the players selected class.
    /// </summary>
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.addItem(itemWorld.getItem());
            itemWorld.destroyItem();
        }
    }
}