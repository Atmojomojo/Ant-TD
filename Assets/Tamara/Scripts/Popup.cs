using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject interactionPanel; 

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
    }

    void ShowInteraction()
    {
        
        if (interactionPanel != null)
        {
            interactionPanel.SetActive(true);
        }
    }

}



