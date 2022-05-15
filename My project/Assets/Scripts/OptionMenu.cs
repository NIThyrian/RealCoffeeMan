using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : Menu
{
    public MainMenu mainMenu;
    private Transform soundButton;
    private Slider sliderX;
    private Slider sliderY;
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
        sliderX = transform.Find("SliderX").GetComponent<Slider>();
        sliderY.onValueChanged.AddListener(delegate { sensivityXChanged(); });
        sliderX = transform.Find("SliderY").GetComponent<Slider>();
        sliderY.onValueChanged.AddListener(delegate { sensivityYChanged(); });
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
    private void sensivityXChanged()
    {
        xSensivity = sliderX.value;
        Debug.Log(xSensivity);
    }
    private void sensivityYChanged()
    {
        ySensivity = sliderY.value;
        Debug.Log(ySensivity);

    }
}
