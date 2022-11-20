using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviourPunCallbacks
{
    //Idk what this is so dont touch it
    [SerializeField] private AppSettings VersionName ;

    //The menus for connecting
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    //Input boxes for connecting
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;
    
    //Just the start button
    [SerializeField] private GameObject StartButton;

    public static Action GetPhotonFriends = delegate{};

    //skin manager
    public CharacterDatabase characterDB;
    public PhotonView photoView;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    Player player;
    private ExitGames.Client.Photon.Hashtable RoomCustomProps = new ExitGames.Client.Photon.Hashtable();
    private ExitGames.Client.Photon.Hashtable PlayerCustomProps = new ExitGames.Client.Photon.Hashtable();

    /// <summary>
    /// Connects to photon network when the main menu opens
    /// </summary>
    private void Awake(){
        //Connects to the photon network
        //PhotonNetwork.ConnectUsingSettings();
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
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
    public override void OnConnectedToMaster(){
        Debug.Log("Connected");
        //Joins lobby
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        //Print to log
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
        PhotonNetwork.NickName = UsernameInput.text;
        PlayerPrefs.SetString("USERNAME", UsernameInput.text);

        //Sets player skin
        //updatePlayerSkin(player);

        //UIInvite.OnRoomInviteAccept += HandleRoomInviteAccept;

        /*
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers=8;
        PhotonNetwork.JoinOrCreateRoom("Main", roomOptions, TypedLobby.Default);
        */

    }
    /*
    public void OnDestroy(){
        UIInvite.OnRoomInviteAccept -= HandleRoomInviteAccept;
    }*/

    /// <summary>
    /// Creates a photon lobby from the user passed name
    /// </summary>
    public void CreateGame(){
        RoomOptions roomOptions = new RoomOptions(){MaxPlayers = 4, BroadcastPropsChangeToAll = true};

        //Random map
        int seed = UnityEngine.Random.Range(0, 1000);
        RoomCustomProps.Add("Seed", seed);
        roomOptions.CustomRoomProperties = RoomCustomProps;
        Debug.Log(seed.ToString());
        PhotonNetwork.CreateRoom(CreateGameInput.text, roomOptions, null);
    }

    /// <summary>
    /// Joins a photon lobby from the user passed name or makes a new one if one with that name does not exist
    /// </summary>
    public void JoinGame(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers=4;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    /// <summary>
    /// Once player joins room, launch the game
    /// </summary>
    public override void OnJoinedRoom(){

            PhotonNetwork.LoadLevel("MainGame");
    }
    /*
    private void HandleRoomInviteAccept(string roomName){
        PlayerPrefs.SetString("PHOTONROOM",roomName);
        if(PhotonNetwork.InRoom){
            PhotonNetwork.LeaveRoom();
        }
        else{
            if(PhotonNetwork.InLobby){
                JoinPlayerRoom();
            }
        }
    }

    private void JoinPlayerRoom(){
        string roomName = PlayerPrefs.GetString("PHOTONROOM");
        PlayerPrefs.SetString("PHOTONROOM", roomName);
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedLobby()
    {
        string roomName = PlayerPrefs.GetString("PHOTONROOM");
        if(!string.IsNullOrEmpty(roomName)){
            JoinPlayerRoom();
        }
        else{
            //PhotonNetwork.CreateRoom(PhotonNetwork.LocalPlayer.UserId);
        }
    }

    */

    public void NextOption()
    {
        selectedOption = selectedOption + 1;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();

    }

    public void BackOption()
    {
        selectedOption = selectedOption - 1;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprtie;
        nameText.text = character.CharacterName;
    }

    private void Save()
    {
        //PlayerPrefs.SetInt("selectedOption", selectedOption);
        PlayerCustomProps["selectedOption"] = selectedOption;
        PhotonNetwork.SetPlayerCustomProperties(PlayerCustomProps);
    }
    /*
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            updatePlayerSkin(targetPlayer);
        }
    }

    void updatePlayerSkin(Player player)
    {
        if (player.CustomProperties.ContainsKey("selectedOption"))
        {
            selectedOption = (int)PlayerCustomProps["selectedOption"];
            PlayerCustomProps["selectedOption"] = (int)PlayerCustomProps["selectedOption"];
        }
        else
        {
            PlayerCustomProps["selectedOption"] = 0;
        }
    }
    */
}
