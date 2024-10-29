using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour
{
    public PlayerInputManager playermanager;
    public GameObject titlePanel;
    public GameObject levelPanel;
    public GameObject finishPanel;
    public GameObject bottleSelect;
    public GameObject bottleSelectBackButton;
    [SerializeField]
    private AudioSource musicSource;

    DataPersistenceManager dm;

    //public ProfileSaved profileSave;


    private void Start()
    {
        titlePanel.SetActive(true);
        levelPanel.SetActive(false);
        finishPanel.SetActive(false);
        dm = DataPersistenceManager.Instance;
    }

    public void StartGame()
    {
        titlePanel.SetActive(false);
        levelPanel.SetActive(true);
        playermanager.enabled = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dm.SaveGame();
    }
    
    public void PlayAds()
    {
        //LATER
    }

    public void StopAds()
    {
        //LATER
    }

    public void SelectBottle()
    {
        Invoke("InvokeSelectBottle", 0.75f);
    } 
    public void InvokeSelectBottle()
    {
        bottleSelect.SetActive(true);
        //profileSave.enabled = true;
    } 

    public void SelectBottleBack() => Invoke("InvokeSelectBottleBack", 0.75f);
    public void InvokeSelectBottleBack()
    {
        bottleSelect.SetActive(false);
        //profileSave.enabled = false;
    } 


    public void Music(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void Vibration()
    {
        //LATER
    }

    public void Quit()
    {
        Application.Quit();
    }
}
