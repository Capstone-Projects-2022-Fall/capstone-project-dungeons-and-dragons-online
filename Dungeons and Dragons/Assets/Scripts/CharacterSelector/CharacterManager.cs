using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using Photon.Pun;
/// <summary>
/// Handles the selecting of characters
/// </summary>
public class CharacterManager : MonoBehaviour
{
    /// <summary>
    ///  This will be the list of characters
    /// </summary>
    public CharacterDatabase characterDB;
    /// <summary>
    /// The players view
    /// </summary>
    public PhotonView photoView;
    /// <summary>
    /// Stores the name of the character
    /// </summary>
    public Text nameText;
    /// <summary>
    /// Generates the sprite in the game
    /// </summary>
    public SpriteRenderer artworkSprite;
    /// <summary>
    /// This is the users selected option
    /// </summary>
    private int selectedOption = 0;

    /// <summary>
    /// When the the manager loads, update the character to the selected option
    /// </summary>
    private void Start()
    {
        UpdateCharacter(selectedOption);
    }

     /// <summary>
    /// Rotates the character to the next one in the data base
    /// </summary>
    public void NextOption()
    {
        selectedOption = selectedOption + 1;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
       /// photoView.RPC("Save", RpcTarget.AllBuffered);
        Save();

    }
    /// <summary>
    /// Rotates the character to the previous one in the data base
    /// </summary>
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

    /// <summary>
    /// Shows the selected character that is passed
    /// </summary>
    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprtie;
        nameText.text = character.CharacterName;
    }

    /// <summary>
    /// Saves the players character
    /// </summary>
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    /// <summary>
    /// Loads the main game
    /// </summary>
    public void playGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
