using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer;
    public PhotonView pv;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        pv = this.gameObject.GetComponent<PhotonView>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        if (!pv.IsMine)//destroy rb for reducing lag;
        {
            Destroy(rb);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)// only dealing with one's own arrow in order to reduce lag
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                PhotonNetwork.Destroy(this.gameObject);//when it pass 1 sec, destroy this arrow on photon.
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
        }

        if (collider.GetComponent<BOSSHealth>() != null)
        {
            BOSSHealth health = collider.GetComponent<BOSSHealth>();
            health.Damage(damage);
        }
    }
}
