using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public bool popupDisable;
    public GameObject popupPanel;
    public GameObject interactionPanel;
    public string targetSceneName = "Map";

    //public void ShowPopup()
    //{
    //    popupPanel.SetActive(true);
    //}

    //public void HidePopup()
    //{
    //    popupPanel.SetActive(false);
    //}

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == targetSceneName)
        {
            Invoke("ShowInteraction", 5f);
        }
       
    }

    private void Update()
    {
        if (popupDisable)
        {
            CancelInvoke();
        }
    }

    void ShowInteraction()
    {
        
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(true);
        }
    }

}



