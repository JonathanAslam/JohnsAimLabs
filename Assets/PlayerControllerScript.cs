using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float mouseSpeedHorizontal = 2f;
    public float mouseSpeedVertical = 2f;
    [SerializeField] Transform cameraHolder;
    private float rotationY = 0f;
    private float rotationX = 0f;


    void Start() {
        //remove cursor from screen when playing on start
        Cursor.visible = false;

        //lock cursor to center of screen, where the crosshair is 
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        //allow x rotation 360 degrees
        // transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSpeedHorizontal);
        rotationX += Input.GetAxisRaw("Mouse X") * mouseSpeedHorizontal;
        //allow y rotation
        rotationY += Input.GetAxisRaw("Mouse Y") * mouseSpeedVertical;
        //clamp x and y rotation to prevent camera rotating too far left or right
            //allow vertical rotation of 30 degrees up and down from starting view, total 60 degrees view 
        rotationY = Mathf.Clamp(rotationY, -30f, 30f);
            //allow horizontal rotation of 50 degrees left and right from starting view, total 100 degrees view
        rotationX = Mathf.Clamp(rotationX, -55f, 55f);

        // negative rotationY to prevent camera movement from being inverted
        cameraHolder.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
        //
    }
}
