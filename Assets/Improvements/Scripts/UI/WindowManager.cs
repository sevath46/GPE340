using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    private Toggle fullScreen;
    public Dropdown resolutionDropdown;

    //Resolutioon list and string list.
    public List<Resolution> resolutionsList = new List<Resolution>();
    public List<string> resString = new List<string>();

    void Awake()
    {
        Resolution[] resolutions = Screen.resolutions; //all resolution
        foreach (Resolution res in resolutions)
        {
         resolutionsList.Add(res); //add resolution in list
            resString.Add(res.width.ToString() + "x" + res.height.ToString()); //string format every resolution
        }
        resolutionDropdown.AddOptions(resString);
    }


    public void ScreenAdjust() 
    {
        
    }
}
