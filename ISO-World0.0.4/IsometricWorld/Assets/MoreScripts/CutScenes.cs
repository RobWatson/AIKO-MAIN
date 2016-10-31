using UnityEngine;
using System.Collections;

public class CutScenes : MonoBehaviour
{

    public Texture[] frames;
    public float framesPerSecond = 10;

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        GetComponent<Renderer>().material.mainTexture = frames[index];


    }
}
