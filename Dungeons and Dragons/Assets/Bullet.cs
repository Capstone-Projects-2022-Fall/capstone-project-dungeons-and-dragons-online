using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool MoveDir = false;
    public float MoveSpeed;
    public float DestoryTime;
    public PhotonView photonView;

    private void Awake()
    {
        
    }

    IEnumerator DestoryByTime()
    {
        yield return new WaitForSeconds(DestoryTime);
        photonView.RPC("DestroyObject", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void ChangeDir_left()
    {
        MoveDir = true;
    }

    [PunRPC]
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (!MoveDir)
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        PhotonView target = collision.gameObject.GetComponent<PhotonView>();

        if (target != null && (!target.IsMine || target.IsSceneView))
        {
            photonView.RPC("DestroyObject", RpcTarget.AllBuffered);
        }
    }
}
