using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class StartUIHandler : MonoBehaviour
{

    [SerializeField] private MainManager mainManager;

    public void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public void OnBatmanClicked()
    {
        
        mainManager.instance.playerChar = MainManager.SUPERHERO_LIST.BATMAN;
        StartGame();
    }
    public void OnSupermanClicked()
    {
        mainManager.instance.playerChar = MainManager.SUPERHERO_LIST.SUPERMAN;
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
