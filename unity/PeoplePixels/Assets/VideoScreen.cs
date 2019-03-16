using UnityEngine;

public class VideoScreen : MonoBehaviour
{
    void Start()
    {
        var videoTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = videoTexture;
        videoTexture.Play();
    }

    void Update()
    {
        
    }
}
