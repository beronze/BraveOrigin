using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


    float verticalRotation = 0;
    public float mouseSensitivity = 2.0f;
    public float verticalAngleLimit = 60.0f;
    GameObject MainCamera;
    

    CheckActiveScreen Chack;

	void Start () {
        MainCamera = this.gameObject.transform.FindChild("Main Camera").gameObject;
        Chack = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();
	}
	

	void LateUpdate () {

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Chack.Alt = !Chack.Alt;
        }
        if (Chack.NullSreen)
        {
            if (Chack.Alt)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                float rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
                transform.Rotate(0, rotationLeftRight, 0);

                verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit / 3);
                MainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
            }
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //HandleMouseRotation ();

        //mouseX = Input.mousePosition.x;
        //mouseY = Input.mousePosition.y;
	}


}
