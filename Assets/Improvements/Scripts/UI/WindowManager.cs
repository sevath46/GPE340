using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    private Toggle fullScreen;
    public Dropdown resolutionDropdown;


    private void Awake()
    {
        // Build resolutions
        resolutionDropdown.ClearOptions();
        List <Resolution> resolutionsList = new List<Resolution>();
        for (int index = 0; index < Screen.resolutions.Length; index++)
        {
            resolutionsList.Add(string.Format("{0} x {1}", Screen.resolutions[index].width, Screen.resolutions[index].height));
        }
        resolutionDropdown.AddOptions(resolutionsList);
    }


    public void FullScreen() 
    {
        
    }
}
