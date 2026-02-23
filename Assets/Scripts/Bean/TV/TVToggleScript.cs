using UnityEngine;

public class TVToggleScript : MonoBehaviour
{
    public GameObject Fons1;
    public GameObject Fons2;
    public GameObject OffImage;
    public GameObject Animation;

    public void ToggleOff()
    {
        if(OffImage != null)
        {
            OffImage.SetActive(!OffImage.activeSelf);
        }
    }
    public void ToggleFons1()
    {
        if(OffImage.activeSelf == false)
        {
            Fons1.SetActive(true);
            Fons2.SetActive(false);
            Animation.SetActive(false);
        }
    }
    public void ToggleFons2()
    {
        if (OffImage.activeSelf == false)
        {
            Fons1.SetActive(false);
            Fons2.SetActive(true);
            Animation.SetActive(false);
        }
    }

    public void ToggleAnimation()
    {
        if (OffImage.activeSelf == false)
        {
            Fons1.SetActive(false);
            Fons2.SetActive(false);
            Animation.SetActive(true);
        }
    }
}

