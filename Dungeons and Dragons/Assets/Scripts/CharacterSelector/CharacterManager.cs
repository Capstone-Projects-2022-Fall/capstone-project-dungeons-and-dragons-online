using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using Photon.Pun;

public class CharacterManager : MonoBehaviour
{

    public CharacterDatabase characterDB;
    public PhotonView photoView;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    private void Start()
    {
        UpdateCharacter(selectedOption);
    }

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
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void playGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
