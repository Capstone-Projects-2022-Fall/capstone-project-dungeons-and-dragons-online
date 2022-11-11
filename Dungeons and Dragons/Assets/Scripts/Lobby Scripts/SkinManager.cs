using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{

    public List<Sprite> skins = new List<Sprite>();
    public GameObject playerskin;
    public SpriteRenderer sr;

    public int selectedSkin;
    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/Photon/PhotonUnityNetworking/Resources/selectedSkin.prefab");
        SceneManager.LoadScene("MainGame");
    }

}
