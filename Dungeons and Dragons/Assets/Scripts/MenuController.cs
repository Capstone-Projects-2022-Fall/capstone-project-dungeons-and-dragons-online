using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //Idk what this is so dont touch it
    [SerializeField] private string VersionName = "0.1";

    //The menus for connecting
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    //Input boxes for connecting
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    //Just the start button
    [SerializeField] private GameObject StartButton;

    /// <summary>
    /// Connects to photon network when the main menu opens
    /// </summary>
    private void Awake(){
        //Connects to the photon network
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    /// <summary>
    /// Changes the players username to the one passed by the user
    /// </summary>
    private void Start(){
        //Displays username menu
        UsernameMenu.SetActive(true);
    }

    /// <summary>
    /// When the user joins the lobby, send a message to the console confirming connection
    /// </summary>
    private void OnConnectedToMaster(){
        //Joins lobby
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        //Print to log
        Debug.Log("Connected");
    }

    /// <summary>
    /// Changes the players username to the one passed by the user
    /// </summary>
    public void ChangeUsernameInput(){
        //Username mus be at least 3 characters in length
        if(UsernameInput.text.Length>=3){
            StartButton.SetActive(true);
        }
        else{  //Otherwise the start button will not appear
            StartButton.SetActive(false);
        }
    }

    /// <summary>
    /// Takes the text from the username input box and send the name to the unity server
    /// </summary>
    public void setUsername(){
        //Turns of username menu
        UsernameMenu.SetActive(false);
        //Sets player username
        PhotonNetwork.playerName = UsernameInput.text;
    }

    /// <summary>
    /// Creates a photon lobby from the user passed name
    /// </summary>
    public void CreateGame(){
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions(){maxPlayers = 8}, null);
    }

    /// <summary>
    /// Joins a photon lobby from the user passed name or makes a new one if one with that name does not exist
    /// </summary>
    public void JoinGame(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers=4;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    /// <summary>
    /// Once player joins room, launch the game
    /// </summary>
    private void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("MainGame");
    }


}
