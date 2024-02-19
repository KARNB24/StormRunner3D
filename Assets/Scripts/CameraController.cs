using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CameraController : MonoBehaviour
{
    public GameObject TPVCamera;
    public GameObject FPVCamera;
    public GameObject SPVCamera;
    public GameObject NameSPVGO;
    public GameObject NameTPVGO;
    public TMP_Text NameTPV;
    public TMP_Text NameSPV; 

    void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
        {
            NameSPV.text = PlayerPrefs.GetString("UserName");
        }
    }


    void Update()
    {
        
        if (Input.GetButtonDown("TPVKey"))
        {
            TPVCamera.SetActive(true);
            FPVCamera.SetActive(false);
            SPVCamera.SetActive(false);
            NameSPVGO.SetActive(false);
            NameTPVGO.SetActive(true);
        }
        if (Input.GetButtonDown("FPVKey"))
        {
            FPVCamera.SetActive(true);
            TPVCamera.SetActive(false);
            SPVCamera.SetActive(false);
            NameSPVGO.SetActive(false);
        }
        if (Input.GetButtonDown("SPVKey"))
        {
            SPVCamera.SetActive(true);
            TPVCamera.SetActive(false);
            FPVCamera.SetActive(false);
            NameSPVGO.SetActive(true);
            NameTPVGO.SetActive(false);
        }
        
    }

    
}
