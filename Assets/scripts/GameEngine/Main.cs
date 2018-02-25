using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public AudioClip ambientSound;

    public float Intensity_Debug;
    public Image IntensityImage;


    // Use this for initialization
    void Start ()
    {
     //   AudioMananger.instance.PlayAmbient(ambientSound);

	}
	
	// Update is called once per frame
	public void Update ()
    {
        if (IntensityImage != null)
        {
            //Intensity_Debug = slimeScript.vida;
            IntensityImage.fillAmount = Intensity_Debug;
        }
    }
}
