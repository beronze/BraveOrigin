using UnityEngine;
using System.Collections;
using System;
public class PlayerController : MonoBehaviour {

    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject m_modle;

    public GameObject Atk_Hit;
    [SerializeField] private GameObject[] Skill;
    public float[] ManaUseSkill;
    public float[] CurrentCooldownSkill, MaxCooldownSkill;
    public float CurrentBuff, MaxBuff;
    public Transform PointEffect;
    [SerializeField] private float[] Delay_Atk;
    public int NumberSkillUse;

    public GameObject Ef_ATK;
    bool Chack_Ef_ATK;

    public GameObject Ef_Run;
    bool Chack_Ef_Run;

    //Item _Item;
    public Transform PointItem;
    public GameObject e_Hp, e_Mp;

    private Vector3 moveDirection = Vector3.zero;
    private float m_RunSpeed;
    private float speed;
    private float Atk_Time,Any_Time,Any_Atk;

    private CheckActiveScreen N_Screen;
    public Facing Fac;
    GameObject Posion;
    PlayerStatus Status;
    Inventory inv;
    void Start () {
        Status = this.GetComponent<PlayerStatus>();
        speed = Status.Speed;
        
        CurrentBuff = MaxBuff;

        inv = GameObject.Find("InventoryManager").GetComponent<Inventory>();

    }

    void Update()
    {
        N_Screen = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {


            //Move
            if (!Fac.onAttack)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= (speed + Status.item_Speed);
            }
            else
                moveDirection *= 0;

            if (moveDirection.x != 0 && moveDirection.z != 0)
                _anim.SetBool("Walk", true);
            else
                _anim.SetBool("Walk", false);


            //Run
			if (Input.GetKey(KeyCode.LeftShift) && moveDirection != new Vector3(0,0,0))
            {
                speed = (Status.Speed + Status.item_Speed) * 1.5f;
                if (moveDirection.x != 0 && moveDirection.z != 0)
                    _anim.SetBool("Run", true);
            }
            else
            {
                speed = Status.Speed;
                _anim.SetBool("Run", false);
            }

            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !Chack_Ef_Run )
            {
                Ef_Run.GetComponent<ParticleSystem>().Play();
                Chack_Ef_Run = true;
            }
            else if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                Ef_Run.GetComponent<ParticleSystem>().Stop();
                Chack_Ef_Run = false;
            }


            //Atk
            Any_Time += Time.deltaTime;
            Any_Atk = Any_Time - Atk_Time;

            if (Input.GetMouseButton(0) && N_Screen.NullSreen)
            {
                _anim.SetBool("Atk", true);
                Atk_Time = Any_Time;
            }
            else if (Any_Atk >= 0.5f)
            {
                _anim.SetBool("Atk", false);
                Any_Time = 0;
                Any_Atk = 0;              
            }

            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("ATK") && !Chack_Ef_ATK)
            {
                Ef_ATK.GetComponent<ParticleSystem>().Play();
                Chack_Ef_ATK = true;
            }
            else if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("ATK"))
            {
                Ef_ATK.GetComponent<ParticleSystem>().Stop();
                Chack_Ef_ATK = false;
            }

            //Skill
            if (Input.GetKeyDown(KeyCode.Alpha1) && CurrentCooldownSkill[0] == 0
                && Status.CurrentMp >= ManaUseSkill[0] && _anim.GetBool("Walk") == false)
            {
                NumberSkillUse = 0;
                _anim.SetBool("Melee", true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && CurrentCooldownSkill[1] == 0
                && Status.CurrentMp >= ManaUseSkill[1] && _anim.GetBool("Walk") == false)
            {
                NumberSkillUse = 1;
                _anim.SetBool("Rage", true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && CurrentCooldownSkill[2] == 0
                && Status.CurrentMp >= ManaUseSkill[2] && _anim.GetBool("Walk") == false)
            {
                Skill[2].SetActive(true);
                CurrentCooldownSkill[2] = MaxCooldownSkill[2];
                CurrentBuff = 0;
                _anim.SetBool("Buff", true);
                Status.buff_Damage += (Int32)Status.Damage * 10 /100;
            }

            else
            {
                _anim.SetBool("Rage", false);
                _anim.SetBool("Melee", false);
                _anim.SetBool("Buff", false);

            }

            //Buff Time
            if (CurrentBuff < MaxBuff)
            {
                CurrentBuff += Time.deltaTime;
            }
            else if (CurrentBuff >= MaxBuff)
            {
                Status.buff_Damage = 0;
                Skill[2].SetActive(false);
            }


            


            //Jump
            _anim.SetBool("Jump", false);
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                _anim.SetBool("Jump", true);
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        //rage
        for (int i = 0; i < Skill.Length; i++)
        {
            if (CurrentCooldownSkill[i] > 0)
            {
                CurrentCooldownSkill[i] -= Time.deltaTime;
            }
            else
            {
                CurrentCooldownSkill[i] = 0;
            }
        }


        //Hp&Mp
        if (Input.GetKeyDown(KeyCode.Alpha4) && inv.ChackStack(0))
        {
            inv.DeleteItem(0);
            Status.CurrentHp += 400;
            Posion = Instantiate(e_Hp, PointItem.position, PointItem.rotation) as GameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && inv.ChackStack(1))
        {
            inv.DeleteItem(1);
            Status.CurrentHp += Status.MaxHp * 30 / 100;
            Posion = Instantiate(e_Hp, PointItem.position, PointItem.rotation) as GameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && inv.ChackStack(2))
        {
            inv.DeleteItem(2);
            Status.CurrentMp += 100;
            Posion = Instantiate(e_Mp, PointItem.position, PointItem.rotation) as GameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) && inv.ChackStack(3))
        {
            inv.DeleteItem(3);
            Status.CurrentMp += Status.MaxMp * 30 / 100;
            Posion = Instantiate(e_Mp, PointItem.position, PointItem.rotation) as GameObject;
        }


        //Die
        if (Status.CurrentHp <= 0 && !_anim.GetBool("Die"))
        {
            _anim.SetBool("Die", true);
            StartCoroutine(Die(1f));
        }

        //Regend HP-MP
        if (Status.CurrentHp >= Status.MaxHp)
            Status.CurrentHp = Status.MaxHp;
        else if (!_anim.GetBool("Die"))
            Status.CurrentHp = Status.CurrentHp + Time.deltaTime * Status.MaxHp / 1000;
        if (Status.CurrentMp >= Status.MaxMp)
            Status.CurrentMp = Status.MaxMp;
        else if (!_anim.GetBool("Die"))
            Status.CurrentMp = Status.CurrentMp + Time.deltaTime * Status.MaxMp / 1000;

    }

    public void ATK()
    {
        GameObject thisEffect = Instantiate(Atk_Hit, PointEffect.position, PointEffect.rotation) as GameObject;
        if (thisEffect != null)
        {
            thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = Status.Damage + Status.item_Damage;

        }
    }
    
    public void TakeDamage()
    {
        CurrentCooldownSkill[NumberSkillUse] = MaxCooldownSkill[NumberSkillUse];
        Status.CurrentMp -= ManaUseSkill[NumberSkillUse];
        GameObject thisEffect = Instantiate(Skill[NumberSkillUse], PointEffect.position, PointEffect.rotation) as GameObject;
        if (thisEffect != null)
        {
            thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = Status.Damage + Status.item_Damage + Status.buff_Damage;

        }
        //StartCoroutine(WaitStop(Delay_Atk[NumberSkillUse]));
    }




    //IEnumerator WaitStop(float waitTime)
    //{
    //    CurrentCooldownSkill[NumberSkillUse] = MaxCooldownSkill[NumberSkillUse];
    //    yield return new WaitForSeconds(waitTime);
    //    if (_anim.GetBool("Walk"))
    //    {
    //        yield break;
    //    }

    //    GameObject thisEffect = Instantiate(Skill[NumberSkillUse], PointEffect.position, PointEffect.rotation) as GameObject;
    //    if (thisEffect != null)
    //    {
    //        thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = GetComponent<PlayerStatus>().Damage;
            
    //    }
    //}

    IEnumerator Die(float waitTime)
    {
        PlayerStatus PS = GetComponent<PlayerStatus>();

        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(waitTime);
        if (PS.Level == 1)
            PS.Exp = 0;
        else
            PS.Exp -= PS.LevelExp[PS.Level - 1] - PS.LevelExp[PS.Level - 2];
        N_Screen.Die.SetActive(true);
        Time.timeScale = 0;
    }

}
