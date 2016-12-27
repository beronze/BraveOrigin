using UnityEngine;
using System.Collections;
using System;

public class BossAI : MonoBehaviour {


    NavMeshAgent nav;
    GameObject player;
    public Animator _anim;
    public bool IsBorn;
	public int m_speed;
    public int search_player = 100, ATK_player = 15;

    [SerializeField] private GameObject[] Skill;
    public float[] CurrentCooldownSkill, MaxCooldownSkill, Delay_Atk;
    public Transform PointEffect;
    public int NumberSkillUse;

    public GameObject Atk_Hit;

    private float timeStage;
    private CheckActiveScreen A_screen;

    public enum StageType { Stage_1, Stage_2, Stage_3 }
    public StageType BossStage;

    string levelStage;
    int bossExp;
    int[] itemAd;
    int[] itemAd2;
    int[] itemAd3;
    int sumExp;

    BebarBoss bebar;
    TimeStage TimeSta;
    PlayerStatus P_Sta;

    Vector3 Py, Em;
    // Use this for initialization
    void Start()
    {
        TimeSta = GameObject.Find("TimeStage").GetComponent<TimeStage>();
        bebar = GameObject.Find("Bebar").GetComponent<BebarBoss>();
        player = GameObject.Find("Player");
        P_Sta = player.GetComponent<PlayerStatus>();
        A_screen = GameObject.Find("DataCenter").GetComponent<CheckActiveScreen>();

        nav = GetComponent<NavMeshAgent>();
        

        if (BossStage.ToString() == "Stage_1")
            bossExp = 80;
        else if (BossStage.ToString() == "Stage_2")
            bossExp = 200;
        else if (BossStage.ToString() == "Stage_3")
            bossExp = 400;

        itemAd = new int[] { 4, 10, 16 };
        itemAd2 = new int[] { 4, 10, 16, 22, 28, 34 };
        itemAd3 = new int[] { 22, 28, 34 };
    }

    void Update()
    {
        //Time Stage
        timeStage += Time.deltaTime;

        CalulationLevelStage();
        TimeSta.t_Stage = timeStage;
        TimeSta.lv_Stage = levelStage;

        //Search Player
        if (bebar == null)
        {
            Py = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            Em = new Vector3(this.transform.position.x, 0, this.transform.position.z);

            transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));

            if (Vector3.Distance(Em, Py) < search_player && Vector3.Distance(Em, Py) > ATK_player)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < search_player + 40)
                {
                    if (IsBorn)
                    {
                        _anim.SetBool("Born", true);
                    }
                }

                if (CurrentCooldownSkill[0] == 0 && Vector3.Distance(Em, Py) < search_player - 40)
                {
					nav.speed = 0;
                    NumberSkillUse = 0;
                    CurrentCooldownSkill[NumberSkillUse] = MaxCooldownSkill[NumberSkillUse];
                    GameObject.Find("BossSounds").transform.GetChild(4).GetComponent<AudioSource>().Play();
                    _anim.SetBool("Rage", true);
                }
				else 
                {
					nav.speed = m_speed;
                    nav.SetDestination(player.transform.position);
                    _anim.SetBool("Rage", false);
                    _anim.SetBool("Run", true);
                }
            }
            else
            {
                nav.speed = 0;
                _anim.SetBool("Run", false);
            }

            if (Vector3.Distance(Em, Py) < ATK_player)
            {
                if (CurrentCooldownSkill[1] == 0)
                {
                    NumberSkillUse = 1;
                    CurrentCooldownSkill[NumberSkillUse] = MaxCooldownSkill[NumberSkillUse];
                    GameObject.Find("BossSounds").transform.GetChild(4).GetComponent<AudioSource>().Play();
                    _anim.SetBool("Melee", true);
                }
                else
                {
                    _anim.SetBool("Melee", false);
                    _anim.SetBool("ATK", true);
                }

            }
            else
            {
                _anim.SetBool("ATK", false);

            }


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


            //Die
            if (GetComponent<EnemyStatus>().CurrentHp < 0.1f)
            {
                StartCoroutine(Die(1.3f));
            }

        }
        else
            this.GetComponent<EnemyStatus>().CurrentHp = this.GetComponent<EnemyStatus>().MaxHp;
            

    }

    bool _Check;

    IEnumerator Die(float waitTime)
    {
        
        if (!_Check)
        {
            _Check = true;
            _anim.SetBool("Die", true);
            GameObject.Find("BossSounds").transform.GetChild(0).GetComponent<AudioSource>().Play();

            dataQuest _data = GameObject.Find("QuestManager").GetComponent<dataQuest>();
            _data._Stage = BossStage.ToString();

            yield return new WaitForSeconds(waitTime);
            A_screen.Hide_AllScreen();
            A_screen.EndStage.SetActive(true);
            A_screen.EndButtom.SetActive(true);

            EndStage _end = GameObject.Find("EndStage Panel").GetComponent<EndStage>();
            UI_Screen data = GameObject.Find("Canvas").GetComponent<UI_Screen>();
            

            if (levelStage == "S")
            {
                _end.itemAmount = 4;
                sumExp += ((bossExp * 2) + (bossExp / 2));
            }
            else if (levelStage == "A")
            {
                _end.itemAmount = 3;
                sumExp += (bossExp * 2);
            }
            else if (levelStage == "B")
            {
                _end.itemAmount = 2;
                sumExp += ((bossExp * 2) - (bossExp / 2));
            }
            else if (levelStage == "C")
            {
                _end.itemAmount = 1;
                sumExp += bossExp;
            }

            P_Sta.Exp += Convert.ToInt32(sumExp);
            data.data.text += "\n ท่านได้รับค่าประสบการณ์ " + sumExp + " หน่วย";

            if (BossStage.ToString() == "Stage_1")
                _end.addItemEnd(_end.itemAmount, itemAd, 3);
            else if (BossStage.ToString() == "Stage_2")
                _end.addItemEnd(_end.itemAmount, itemAd2, 6);
            else if (BossStage.ToString() == "Stage_3")
                _end.addItemEnd(_end.itemAmount, itemAd3, 3);
            
            GameObject.Find("InventoryManager").GetComponent<Inventory>().ScrollDown();
            
            _end.LavelStage = levelStage;
            _end.TimeStage = timeStage;
            _data._Degree = _end.LavelStage;
            _data.QuestEnd();
            Destroy(gameObject, 1.4f);

            
        } 
        
    }

    void CalulationLevelStage()
    {
        if (timeStage > 300)
            levelStage = "C";
        else if (timeStage > 240)
            levelStage = "B";
        else if (timeStage > 180)
            levelStage = "A";
        else        
            levelStage = "S";
    }

    public void TakeDamage()
    {
        StartCoroutine(WaitStop(Delay_Atk[NumberSkillUse]));
    }



    IEnumerator WaitStop(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject thisEffect = Instantiate(Skill[NumberSkillUse], PointEffect.position, PointEffect.rotation) as GameObject;
        if (thisEffect != null)
        {
            thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = GetComponent<EnemyStatus>().Damage;

        }
    }

    public void Atk()
    {
        StartCoroutine(WaitAtk(0.3f));
    }

    IEnumerator WaitAtk(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject thisAtk = Instantiate(Atk_Hit, PointEffect.position, PointEffect.rotation) as GameObject;
        if (thisAtk != null)
        {
            thisAtk.GetComponentInChildren<EffectPropertie>().PureDamage = GetComponent<EnemyStatus>().Damage;
        }
    }
}
