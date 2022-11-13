using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;
using HashTable = ExitGames.Client.Photon.Hashtable;

public class ArcherController : MonoBehaviourPunCallbacks
{
    private PhotonView pv;
    private Transform tr;
    private Rigidbody2D rb;
    private SpriteRenderer spr;

    public Animator animator;// copy from player
    public GameObject PlayerCamera;// copy from player
    public Text PlayerNameText;
    public float speed;
    public float arrowPower;// the power of the weapon
    public int hp;
    [SerializeField]
    private Image hp_image;

    // Start is called before the first frame update
    void Start()
    {
        pv = this.gameObject.GetComponent<PhotonView>();
        tr = this.gameObject.GetComponent<Transform>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        hp = 100;

        if (pv.IsMine)
        {
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.NickName;

        }
        else
        {
            PlayerNameText.text = pv.Owner.NickName;
            PlayerNameText.color = Color.cyan;
            Destroy(rb);////destroy rb for reducing lag;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            Control();
        }
    }
    void Control()
    {


        if (Input.GetKey(KeyCode.A))
        {
            tr.position += Vector3.left * speed * Time.deltaTime;
            spr.flipX = true;//when go to leftside, flip x of renderer
            animator.SetFloat("Horizontal", tr.position.x);
        }

        if (Input.GetKey(KeyCode.D))
        {
            tr.position += Vector3.right * speed * Time.deltaTime;
            spr.flipX = false;
            animator.SetFloat("Horizontal", tr.position.x);
        }

        if (Input.GetKey(KeyCode.W))
        {
            tr.position += Vector3.up * speed * Time.deltaTime;
            animator.SetFloat("Vertical", tr.position.y);
        }

        if (Input.GetKey(KeyCode.S))
        {
            tr.position += Vector3.down * speed * Time.deltaTime;
            animator.SetFloat("Vertical", tr.position.y);
        }

        /////////////////////////////////////////////////////////
        
        if (Input.GetMouseButtonDown(0))// leftclick mouse for Archer's attack
        {//checking spr is fliping or not, if it is flip, shoot nagetive/left, else shoot normally/right
            float force = spr.flipX ? -arrowPower : arrowPower;
            float _offset = spr.flipX ? -0.1f : 0.1f;
            Vector3 offset = new Vector3(_offset, 0, 0);
            GameObject arrowObj = PhotonNetwork.Instantiate("PhotonArrow", tr.position + offset, Quaternion.identity);
            Rigidbody2D arb = arrowObj.GetComponent<Rigidbody2D>();
            SpriteRenderer _spr = arrowObj.GetComponent<SpriteRenderer>();
            _spr.flipX = _offset < 0;
            arb.AddForce(new Vector2(force, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pv.IsMine)
        {
            if (collision.gameObject.tag == "Weapon")// it your got hit by a obj with tag"weapon"
            {
                Arrow arrow = collision.gameObject.GetComponent<Arrow>();
                if (!arrow.pv.IsMine)//if you got hit by other player
                {
                    HashTable table = new HashTable();
                    hp -= 10;
                    table.Add("hp", hp);// create a hashtable, after losing hp, update the hp to the table
                    PhotonNetwork.LocalPlayer.SetCustomProperties(table);// update your local-hp with updated-hp of table
                    if(hp <= 0)
                    {
                        PhotonNetwork.Destroy(this.gameObject);// and send it to all players
                    }
                }
            }
        }
    }

    public void UpdateHpBar()
    {
        float percent = (float)hp/100;
        hp_image.transform.localScale = new Vector3(percent, hp_image.transform.localScale.y, hp_image.transform.localScale.z);//update hp bar percentage by changes on x axis
    }

    //this method is for updating player's property, in this case, namely the hashtable of hp
    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, HashTable changedProps)
    {
        if(targetPlayer == pv.Owner)
        {
            hp = (int)changedProps["hp"];
            UpdateHpBar();
        }
    }
}
