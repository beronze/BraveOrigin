using UnityEngine;
using System.Collections;

public class NaveMeshEnemy : MonoBehaviour {

	NavMeshAgent nav;
	GameObject player;

	public Animator _anim;
    public bool IsBorn;
	public int m_speed;
	public int search_player = 100, ATK_player= 17;

    public Transform PointEffect;

    public GameObject Atk_Hit;

    BebarBoss bebar;

    Vector3 Py, Em;
    // Use this for initialization
    void Start () {
        bebar = GameObject.Find("Bebar").GetComponent<BebarBoss>();
        player = GameObject.Find("Player");
		nav = GetComponent<NavMeshAgent> ();

	}

	void Update () {
        Py = new Vector3(player.transform.position.x , 0 ,player.transform.position.z);
        Em = new Vector3(this.transform.position.x , 0 , this.transform.position.z);

        if (Vector3.Distance(Em, Py) < search_player && Vector3.Distance(Em, Py) > ATK_player)
        {
            if (IsBorn)
            {
                _anim.SetBool("Born", true);
            }

            nav.speed = m_speed;
            nav.SetDestination(player.transform.position);
            _anim.SetBool("Run", true);
        }
        else
        {
            nav.speed = 0;
            _anim.SetBool("Run", false);
        }

		if (Vector3.Distance (Em, Py) < ATK_player)
        {
			_anim.SetBool ("ATK", true);
            transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
            
        }
        else
        {
			_anim.SetBool ("ATK", false);
           
		}


        if (GetComponent<EnemyStatus>().CurrentHp < 0.1f)
        {           
            _anim.SetBool("Die", true);
            StartCoroutine(Die(1.4f));
            
        }


    }

    IEnumerator Die(float waitTime)
    {
        AudioSource s_die = GameObject.Find("MonsterSounds").transform.GetChild(0).GetComponent<AudioSource>();
        s_die.Play();
        yield return new WaitForSeconds(waitTime);
        if (bebar != null)
        {
            bebar.bebarNum++;
        }
        Destroy(gameObject, 0f);
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
