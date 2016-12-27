using UnityEngine;
using System.Collections;

public class Facing : MonoBehaviour {

    private CheckActiveScreen N_Screen;
    public bool onAttack;

    void Start ()
    {
        N_Screen = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!N_Screen.NullSreenNPC || N_Screen.NullSreen && !onAttack)
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                transform.localEulerAngles = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                transform.localEulerAngles = new Vector3(0, 45, 0);

            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                transform.localEulerAngles = new Vector3(0, 90, 0);

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                transform.localEulerAngles = new Vector3(0, 135, 0);

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                transform.localEulerAngles = new Vector3(0, 180, 0);

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                transform.localEulerAngles = new Vector3(0, 225, 0);

            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                transform.localEulerAngles = new Vector3(0, 270, 0);

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                transform.localEulerAngles = new Vector3(0, 315, 0);
        }
    }
}
