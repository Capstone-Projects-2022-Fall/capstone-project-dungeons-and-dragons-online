using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GotoPVP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene("BattleMap");
    }
}