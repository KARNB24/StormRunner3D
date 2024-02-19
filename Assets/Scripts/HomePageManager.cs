using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{
    public GameObject UnityChan;
    public GameObject AboutPanel;
    public GameObject ControlsPanel;

    public AudioClip clickSound;



    

    public void disableControlsPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        UnityChan.SetActive(true);
        ControlsPanel.SetActive(false);
    }

    public void EnableControlsPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        UnityChan.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void disableAboutPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        AboutPanel.SetActive(false);
        UnityChan.SetActive(true);
    }
    public void EnableAboutPanel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        UnityChan.SetActive(false);
        AboutPanel.SetActive(true);
    }
    public void GoToGame()
    {
        PlayerPrefs.DeleteKey("snow");
        SceneManager.LoadScene("GameScene");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);

    }
    

   

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
