using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public AudioClip ambient;
    public float Intensity_Debug;
    public Image IntensityImage;

    void Start ()
    {
        AudioMananger.instance.PlayAmbient(ambient);
	}
	
	public void Update ()
    {
        if (IntensityImage != null)
        {
            Intensity_Debug = slimeScript.vida;
            IntensityImage.fillAmount = Intensity_Debug;
        }
    }
}
