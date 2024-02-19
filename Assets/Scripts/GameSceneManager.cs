using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
public class GameSceneManager : MonoBehaviour
{
    public TMP_Text tmScore;
    public TMP_Text tmHS;
    public TMP_Text tmTimeLeft;
    public TMP_Text tmName;

    private int MAX_TIME = 360;
    private int SCORE_INCREMENT = 10;
    private int currentTime;
    private int currentScore;
    private int highScore;
    
    public GameObject GameOverPanel;
    public GameObject UnityChan;
    public GameObject Camera;
    public AudioClip clickSound;
    public AudioClip scoreSound;
    public AudioClip explosionSound;

    public AudioClip checkpointsound;

    private int TIME_INCREMENT = 30;


    public GameObject player;


    public static GameSceneManager instance;
    
    private void Awake()
    {
        instance = this;
    }


    private IEnumerator disablePlayerMovement()
    {
        yield return new WaitForSeconds(3f);
        UnityChan.gameObject.SetActive(false);
        
    }

    private IEnumerator EnableGameOverPanel()
    {
        yield return new WaitForSeconds(5f);
        GameOverPanel.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
    }

    

    public void PlayAgain()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene("GameScene");
        
    }

    public void GoHome()
    {

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene("HomeScene");
    }

    public void Quit()
    {
        PlayerPrefs.DeleteKey("snow");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene("HomeScene");
    }

    

    // Start is called before the first frame update
    void Start()
    {

        

        currentTime = MAX_TIME;

        if(PlayerPrefs.HasKey("HS"))
        {
            highScore = PlayerPrefs.GetInt("HS");
        }
        else
        {
            highScore = 0;
        }

        if (PlayerPrefs.HasKey("UserName"))
        {
            tmName.text = PlayerPrefs.GetString("UserName");
        }

        tmHS.text = "High Score: " + highScore;

        StartCoroutine("LoseTime");

        
        //anim = GetComponentInChildren<Animator>();




    }

    private void UpdateLabels()
    {
        
        tmScore.text = "Score: " + currentScore;
        DisplayTimeInMinandSec(currentTime);
    }

    void DisplayTimeInMinandSec(int timetoDisplay)
    {
        int min = Mathf.FloorToInt(timetoDisplay / 60);
        int sec = Mathf.FloorToInt(timetoDisplay % 60);

        tmTimeLeft.text = "Time Left: "+ string.Format("{0:00}:{1:00}", min, sec);
    }
    
    
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;

            if (currentTime % 5 == 0)
            {
                currentScore += SCORE_INCREMENT;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(scoreSound);
            }

            if (currentTime % 6 == 0)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(explosionSound);
            }

            if(PlayerPrefs.HasKey("CheckPointReached"))
            {
                if (PlayerPrefs.GetInt("CheckPointReached")==1)
                {
                    GameObject.Find("CheckPointCanvas").GetComponent<PanelFader>().FadeOut();
                    currentTime += TIME_INCREMENT;
                    currentScore += 30;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(checkpointsound);
                    PlayerPrefs.SetInt("CheckPointReached", 0);
                    

                }
            }

            if (currentTime <= 0)
            {

                
                break;
            }
        }
        GameOver();
        StartCoroutine(EnableGameOverPanel());
        StartCoroutine(disablePlayerMovement());
    }

    public void GameOver()
    {
        
        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt("HS", currentScore);
        }
        player.GetComponent<Animator>().SetTrigger("Death");



    }



    // Update is called once per frame
    void Update()
    {
        
        UpdateLabels();

        
        
        

    }
}
