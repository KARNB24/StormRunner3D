using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class YouWin : MonoBehaviour
{
    public GameObject YouWinPanel;
    
    public GameObject UnityChan;
    public GameObject GameSceneManager1;

     


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            YouWinPanel.SetActive(true);
            UnityChan.gameObject.SetActive(false);
            GameSceneManager1.SetActive(false);
            GameSceneManager.instance.GameOver();
            Cursor.lockState = CursorLockMode.None;



        }
    }
}
