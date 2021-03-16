using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = Pause(isPaused);
        }
    }
    private bool Pause(bool pausing) 
    {
        if (pausing)
        {
            Time.timeScale = 1;
            return pausing = false;
        }
        else
        {
            Time.timeScale = 0;
            return pausing = true;
        }
    }
}
