using UnityEngine;
using System.Collections;

public class Anim_Player : MonoBehaviour {
    Animator anim;

    AudioSource a_Walk, a_Run, a_Die;
    bool Check, Check2, Check3;

    
    void Start()
    {
        anim = this.GetComponent<Animator>();

        GameObject PS = GameObject.Find("PlayerSounds");
        a_Walk = PS.transform.GetChild(12).GetComponent<AudioSource>();
        a_Run = PS.transform.GetChild(11).GetComponent<AudioSource>();
        a_Die = PS.transform.GetChild(2).GetComponent<AudioSource>();
    }

    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") && !Check)
        {
            a_Walk.Play();
            Check = true;
        }
        else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Check = false;
            a_Walk.Stop();
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !Check2)
        {
            a_Run.Play();
            Check2 = true;
        }
        else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            Check2 = false;
            a_Run.Stop();
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && !Check3)
        {
            a_Die.Play();
            Check3 = true;
        }
        else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            Check3 = false;
            a_Die.Stop();
        }

    }

}
