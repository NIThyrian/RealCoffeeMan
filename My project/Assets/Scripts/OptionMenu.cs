using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : Menu
{
    public MainMenu mainMenu;
    private Transform soundButton;
    static public bool soundEnabled;
    static public float xSensivity;
    static public float ySensivity;
    // Start is called before the first frame update
    void Start()
    {
        soundEnabled = true;
        Transform playButton = transform.Find("BackButton");
        playButton.GetComponent<Button>().onClick.AddListener(delegate { backOptionClicked(); });
        soundButton = transform.Find("SoundButton");
        soundButton.GetComponent<Button>().onClick.AddListener(delegate { soundClicked(); });
    }
    private void backOptionClicked()
    {
        show(false);
        mainMenu.show(true);
    }
    private void soundClicked()
    {
        string text = "Enable Sound";
        if(soundEnabled)
        {
            text = "Disable Sound";
        }
        soundButton.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        soundEnabled = !soundEnabled;
    }

}
