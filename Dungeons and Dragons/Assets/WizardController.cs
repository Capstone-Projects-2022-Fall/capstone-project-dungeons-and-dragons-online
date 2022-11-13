using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WizardController : MonoBehaviour
{
    private PhotonView pv;
    private Transform tr;
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pv = this.gameObject.GetComponent<PhotonView>();
        tr = this.transform;

        if (!pv.IsMine)
        {
            Destroy(rb);
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


        if (Input.GetKey(KeyCode.LeftArrow | KeyCode.A))
        {
            tr.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow | KeyCode.D))
        {
            tr.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow | KeyCode.W))
        {
            tr.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow | KeyCode.S))
        {
            tr.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.F))// wizard's attack
        {
            PhotonNetwork.Instantiate("PhotonArrow", tr.position, Quaternion.identity);
        }
    }
    
}
