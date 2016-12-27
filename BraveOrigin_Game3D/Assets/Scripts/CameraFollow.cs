using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform Target;

    void Start()
    {
        Target = GameObject.Find("Player").transform;

    }

    void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, transform.position.y, Target.position.z);
    }
}
