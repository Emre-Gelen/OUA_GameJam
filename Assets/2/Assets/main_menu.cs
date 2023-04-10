using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
   public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void mainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    
    public void creditsMenu()
    {
        SceneManager.LoadScene("creditsmenu");
    }
    
    public void quitGame()
    {
        Application.Quit();
    }
}
