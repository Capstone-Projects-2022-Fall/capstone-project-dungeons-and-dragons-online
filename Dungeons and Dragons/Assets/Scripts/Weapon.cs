using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private void FixedUpdate()
    {
        
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
        m_mousePosition.z = 0;
        Animator animator;

        
        float m_weaponAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
        if (transform.position.x < m_mousePosition.x)
        {
            m_weaponAngle = -m_weaponAngle;
        }

        
        if (m_weaponAngle > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (m_weaponAngle < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        
        transform.eulerAngles = new Vector3(0, 0, m_weaponAngle);

    }
}
