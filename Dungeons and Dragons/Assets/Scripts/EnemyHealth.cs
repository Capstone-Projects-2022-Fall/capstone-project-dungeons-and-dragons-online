using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health = 100;

    // Update is called once per frame
    void Update()
    {
        // Testing Onlys
        if (Input.GetKeyDown(KeyCode.O))
          {
              Damage(10);
             // healthBar.SetSize();

          }

    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have a negative damage");
        }

        this.health -= amount;

        StartCoroutine(VisualIndicator(Color.red));

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("dead");
        Destroy(gameObject);
    }
}
