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
    private TextMeshProUGUI sliderXValue;
    private TextMeshProUGUI sliderYValue;

    static public bool soundEnabled = true;
    static public float xSensivity = 50;
    static public float ySensivity = 50;

    void Start() {
        Transform backButton = transform.Find("BackButton");
        backButton.GetComponent<Button>().onClick.AddListener(delegate { backOptionClicked(); });

        soundButton = transform.Find("SoundButton");
        soundButton.GetComponent<Button>().onClick.AddListener(delegate { soundClicked(); });

        sliderX = transform.Find("SliderXPanel").GetChild(0).GetComponent<Slider>();
        sliderX.onValueChanged.AddListener(delegate { sensivityXChanged(); });
        sliderXValue = transform.Find("SliderXPanel").GetChild(2).GetComponent<TextMeshProUGUI>();

        sliderY = transform.Find("SliderYPanel").GetChild(0).GetComponent<Slider>();
        sliderY.onValueChanged.AddListener(delegate { sensivityYChanged(); });
        sliderYValue = transform.Find("SliderYPanel").GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    private void backOptionClicked() {
        show(false);
        mainMenu.show(true);
    }

    private void soundClicked() {
        string text = "Enable Sound";
        if(soundEnabled) text = "Disable Sound";
        soundButton.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        soundEnabled = !soundEnabled;
    }

    private void sensivityXChanged() {
        sliderXValue.text = sliderX.value.ToString();
        xSensivity = sliderX.value;
    }

    private void sensivityYChanged() {
        sliderYValue.text = sliderY.value.ToString();
        ySensivity = sliderY.value;
    }
}
