using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public float Intensity_Debug;
     public Image IntensityImage;
    public void Update()
    {
        if (IntensityImage != null)
        {
        //    Intensity_Debug = slimeScript.vidaStatic;
            IntensityImage.fillAmount = Intensity_Debug;
        }
    }
}
