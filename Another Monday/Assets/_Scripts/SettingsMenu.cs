using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer auidioMixer;
	Resolution[] resolutions;
	public Dropdown resolutionDropDown;



	public void SetVolume (float volume)
	{
		auidioMixer.SetFloat ("VolumeMaster", volume);
	}

	public void SetQuality (int qualityIndex)
	{
		QualitySettings.SetQualityLevel (qualityIndex);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	public void SetResolution (int resolutionIndex)
	{
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}



	// Use this for initialization
	void Start ()
	{
		resolutions = Screen.resolutions;
		resolutionDropDown.ClearOptions();

		List<string> options = new List<string> ();
		int currentResoultion = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions [i].width + " X " + resolutions [i].height;
			options.Add (option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentResoultion = i;
			}
		}

		resolutionDropDown.AddOptions (options);
		resolutionDropDown.value = currentResoultion;
		resolutionDropDown.RefreshShownValue ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
