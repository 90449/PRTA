using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    public Canvas canvas;
    private int currentCamera = 0;

    void Start()
    {
        // Zet alle cameras uit behalve de eerste
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        // Koppel de canvas aan de eerste camera
        canvas.worldCamera = cameras[currentCamera];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Zet huidige camera uit
            cameras[currentCamera].gameObject.SetActive(false);
            // Wissel naar de volgende camera
            currentCamera = (currentCamera + 1) % cameras.Length;
            // Zet nieuwe camera aan
            cameras[currentCamera].gameObject.SetActive(true);
            // Koppel canvas aan nieuwe camera
            canvas.worldCamera = cameras[currentCamera];
        }
    }
}