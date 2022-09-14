using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;


    private void Start()
    {
         bar = transform.Find("HealthBar");
    }

    // Update is called once per frame
    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
