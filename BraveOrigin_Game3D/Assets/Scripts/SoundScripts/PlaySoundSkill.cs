using UnityEngine;
using System.Collections;

public class PlaySoundSkill : MonoBehaviour {

    public string WhatSounds;
    public int Melee, Rage;
    public float WaitMelee, WaitRage;

    Animator anim;

    AudioSource a_Rage, a_Melee;
    bool Check, Check2;


    void Start()
    {
        anim = this.GetComponent<Animator>();

        GameObject PS = GameObject.Find(WhatSounds);
        a_Rage = PS.transform.GetChild(Rage).GetComponent<AudioSource>();
        a_Melee = PS.transform.GetChild(Melee).GetComponent<AudioSource>();
    }

    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Rage Skill") && !Check)
        {
            StartCoroutine(WaitRageSkill(WaitRage));
            Check = true;
        }
        else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Rage Skill"))
        {
            Check = false;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Melee Skill") && !Check2)
        {
            StartCoroutine(WaitMeleeSkill(WaitMelee));
            Check2 = true;
        }
        else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Melee Skill"))
        {
            Check2 = false;
        }


    }

    IEnumerator WaitRageSkill(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        a_Rage.Play();
    }

    IEnumerator WaitMeleeSkill(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        a_Melee.Play();
    }
}
