using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject interactionPanel;
    public string targetSceneName = "Map";

    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }

    private void Start()
    {
        
        Invoke("ShowInteraction", 5f);
       

        if (SceneManager.GetActiveScene().name == targetSceneName)
        {
            Invoke("ShowInteraction", 5f);
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



