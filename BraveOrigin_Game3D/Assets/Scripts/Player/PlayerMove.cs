using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float _speedPlayer;
	public float _speddRota;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void FixedUpdate () {
		float v = Input.GetAxis ("Vertical") * _speedPlayer * Time.deltaTime;
		transform.Translate (0, 0, v);
		float h = Input.GetAxis ("Horizontal") * _speddRota * Time.deltaTime;
		transform.Translate (h, 0, 0);
	}
}
