using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public  void OnResume() 
    {
        GameManager.GM.Pause(true);
    }
   public  void OnQuit() 
    {
        Application.Quit();
    }
}
