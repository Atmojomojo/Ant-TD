using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddMap : MonoBehaviour
{
    public void Awake()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
