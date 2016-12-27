using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDamage : MonoBehaviour {

    private Camera m_Camera;


	void Start () {
        
        m_Camera = Camera.main;
        Destroy(gameObject, 1);
        
	}
	
	
	void Update () {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);

	}
}
