using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    private Toggle fullScreen;
    public Dropdown resolutionDropdown, qualityDropdown;

    //Resolutioon list and string list.
    public List<Resolution> resolutionsList = new List<Resolution>();
    public List<string> resString, qualString = new List<string>();

    void Awake()
    {
        Resolution[] resolutions = Screen.resolutions; //grabs all resolution
        //for each resolution
        foreach (Resolution res in resolutions)
        {
            //add resolution in list
            resolutionsList.Add(res);
            //add the resolution to a string list.
            resString.Add(res.width.ToString() + "x" + res.height.ToString());
        }
        //Add the entire list to the dropdown.
        resolutionDropdown.AddOptions(resString);

        //Add quality values to string list.
        for (int i = 0; i < QualitySettings.names.Length; i++ )
        {
            qualString.Add(QualitySettings.names[i]);
        }
        //Add quality settings.
        qualityDropdown.AddOptions(qualString);
    }


    public void ScreenAdjust() 
    {
        //Set resolution of the screen and window vs fullscreen base on dropdown value.
        Screen.SetResolution(resolutionsList[resolutionDropdown.value].width, resolutionsList[resolutionDropdown.value].height, fullScreen.isOn);
        //Set quality of game.
        QualitySettings.SetQualityLevel(qualityDropdown.value, true);

    }
}
