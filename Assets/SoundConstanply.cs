using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConstanply : MonoBehaviour
{
    public List<AudioSource> list = new();
    void Start()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Play();
        }
    }
}
