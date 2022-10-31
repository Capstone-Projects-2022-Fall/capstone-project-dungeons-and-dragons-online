using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayInvites : MonoBehaviour
{
    [SerializeField] private Transform inviteContainer;
    [SerializeField] private UIInvite uIInvitePrefab;
    [SerializeField] private RectTransform contentArea;
    [SerializeField] private Vector2 originalSize;
    [SerializeField] private Vector2 increaseSize;

    private List<UIInvite> invites;
    private void Awake(){
        invites = new List<UIInvite>();
        contentArea = inviteContainer.GetComponent<RectTransform>();
        originalSize = contentArea.sizeDelta;
        increaseSize = new Vector2(0, uIInvitePrefab.GetComponent<RectTransform>().sizeDelta.y);
        PhotonChatController.OnRoomInvite += HandleRoomInvite;
        UIInvite.OnInviteAccept += HandleInviteAccept;
        UIInvite.OnInviteDecline += HandleInviteDecline;
    }

    private void OnDestroy(){
        PhotonChatController.OnRoomInvite -= HandleRoomInvite;
        UIInvite.OnInviteAccept -= HandleInviteAccept;
        UIInvite.OnInviteDecline -= HandleInviteDecline;
    }

    private void HandleRoomInvite(string friend, string room){
        Debug.Log("invite for " + friend + " for room " + room);
        UIInvite uIInvite = Instantiate(uIInvitePrefab, inviteContainer);
        uIInvite.Initialize(friend, room);
        contentArea.sizeDelta += increaseSize;
        invites.Add(uIInvite);
    }

    private void HandleInviteAccept(UIInvite invite){
        if(invites.Contains(invite)){
            invites.Remove(invite);
            Destroy(invite.gameObject);
        }
    }

    private void HandleInviteDecline(UIInvite invite){
        if(invites.Contains(invite)){
            invites.Remove(invite);
            Destroy(invite.gameObject);
        }
    }
}
