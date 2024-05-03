using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonActivation : MonoBehaviour
{
    public GameObject slider;

    public void Switch()
    {
        slider.SetActive(!slider.activeInHierarchy);
    }
}
