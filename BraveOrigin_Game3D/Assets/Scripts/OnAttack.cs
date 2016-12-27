using UnityEngine;
using System.Collections;

public class OnAttack : StateMachineBehaviour {

    public bool Start;

    public void OnStateEnter()
    {
        if (Start)
            GameObject.Find("Player").transform.GetChild(0).GetComponent<Facing>().onAttack = true;
    }

	public void OnStateExit() 
    {
        if(!Start)
            GameObject.Find("Player").transform.GetChild(0).GetComponent<Facing>().onAttack = false;
	}

}
