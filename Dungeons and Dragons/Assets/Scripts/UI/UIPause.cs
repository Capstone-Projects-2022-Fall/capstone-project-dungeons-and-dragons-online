using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIPause : MonoBehaviour
{
    public GameObject PauseCanvas;
    public TMP_Text AIToggleText;

    private bool isPaused = false;

    private bool isAI = false;

    [SerializeField] private GameObject ResumeButton;
    [SerializeField] private GameObject AIToggleButton;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pause();
        } else if(Input.GetKeyDown(KeyCode.Escape) && isPaused) {
            resume();
        }
    }

    private void pause(){
        PauseCanvas.SetActive(true);
        isPaused = true;
    }

    public void resume(){
        PauseCanvas.SetActive(false);
        isPaused = false;
    }

    public void toggleAI(){
        if(isAI == false){

            isAI = true;
            AIToggleText.text = "Toggle AI: On";
            
        } else {
            isAI = false;
            AIToggleText.text = "Toggle AI: Off";
        }
    }


    
}
