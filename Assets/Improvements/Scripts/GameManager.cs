using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static pause bool so we can manual pause and unpause any Objects in the game  that arent listening to the time scale.
    public static GameManager GM;
    public static bool isPaused;
    public int playerLives;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Text playerLivesText;
    private string playerLivesWording;

    void Awake() 
    {
        //Set the GM as singleton
        if (GM != null)
        {
            GameObject.Destroy(GM);
        }
        else 
        {
            GM = this;
            DontDestroyOnLoad(this);
        }
        //SetPlayerLives Text
        playerLivesWording = playerLivesText.text;
        playerLivesText.text = playerLivesWording + " " + playerLives;
        //When game first starts, isPaused is false. 
        isPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        //If user presses escape key, pause or unpause game.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = Pause(isPaused);
        }
    }
    public bool Pause(bool pausing) 
    {
        if (pausing)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            return pausing = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            return pausing = true;
        }
    }
    public void AdjustPlayerLives(GameObject player) 
    {
        playerLives--;
        playerLivesText.text = playerLivesWording + " " + playerLives;
        if (playerLives != 0) 
        {
            player.GetComponent<Player>().health = player.GetComponent<Player>().maxHealth;
        }
    }
}
