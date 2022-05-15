using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool soundOn;
    private GameObject creds;
    // Start is called before the first frame update
    void Start()
    {
        soundOn = true;
        setBtnActions();
    }

    private void setBtnActions()
    {
        Transform playButton = transform.Find("PlayButton");
        playButton.GetComponent<Button>().onClick.AddListener(delegate { playClicked(); });
        Transform soundButton = transform.Find("SoundButton");
        soundButton.GetComponent<Button>().onClick.AddListener(delegate { soundClicked(); });
        Transform creditsButton = transform.Find("CreditsButton");
        creditsButton.GetComponent<Button>().onClick.AddListener(delegate { creditsClicked(); });
        Transform quitButton = transform.Find("QuitButton");
        quitButton.GetComponent<Button>().onClick.AddListener(delegate { quitClicked(); });
    }
    private void playClicked()
    {
        SceneManager.LoadSceneAsync("map");
    }
    private void soundClicked()
    {
        soundOn = false;
    }
    private void creditsClicked()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        creds = GameObject.FindGameObjectWithTag("creds");
        creds.SetActive(true);
    }
    private void quitClicked()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
