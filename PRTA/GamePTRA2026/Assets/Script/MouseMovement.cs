using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltTime is the time between frames
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //control rotation around x axis (look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //control rotation around y axis (look left and right)
        yRotation += mouseX;

        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
