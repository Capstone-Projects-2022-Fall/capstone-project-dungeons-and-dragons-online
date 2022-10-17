using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInvitesButton : MonoBehaviour
{
    [SerializeField] private GameObject InviteMenu;
    public void Awake(){
        InviteMenu.SetActive(false);
    }

    public void clickInvite(){
        if(InviteMenu.activeSelf){
            InviteMenu.SetActive(false);
        } else{
            InviteMenu.SetActive(true);
        }
        
    }

}
