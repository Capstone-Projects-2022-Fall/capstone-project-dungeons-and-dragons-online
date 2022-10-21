using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIInvitePlayer : MonoBehaviour
{
    [SerializeField] private TMP_InputField displayName;
    public static Action<String> OnAddFriend = delegate {};
    string userName;

    public static Action<string> OnInvitePlayer = delegate { };
    public void InviteAPlayer()
    {
        userName = displayName.text;
        Debug.Log("You have invited player: " + userName);
        OnInvitePlayer?.Invoke(userName);
    }

}
