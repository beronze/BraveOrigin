using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	Animator _anim;
	public float MoveSpeed;

	public GameObject Skill;
	public Transform SkillPoint;
    bool C_Enemy;

	void Start () {
		_anim = GetComponent<Animator> ();
	}
	
	void Update () {
        _anim.SetFloat("CurrentHp", GetComponent<EnemyStatus>().CurrentHp);

        if (!_anim.GetBool("Collision"))
        {
            float offsetX = MoveSpeed * Time.deltaTime;
            transform.position = transform.position - new Vector3(offsetX, 0, 0);
        }  
	}

	void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.tag == "Player") 
		{
            _anim.SetBool("Collision", true);
		}
	}

	public void TakeDamage()
	{
        GameObject thisEffect = Instantiate(Skill, SkillPoint.position,SkillPoint.rotation) as GameObject;
        if (thisEffect != null)
        {

            thisEffect.GetComponentInChildren<EffectPropertie>().PureDamage = GetComponent<EnemyStatus>().Damage;

        }
	}


    IEnumerator _Waiting()
    {
        _anim.SetBool("Collision", false);
        yield return new WaitForSeconds(Random.Range(0.9F, 3.0F));
        _anim.SetBool("Collision", true);
        
    }
    public void CancelAttack()
    {
        StartCoroutine(_Waiting());
    }

	public void Die()
	{
		_anim.SetBool ("IsDie", true);
	}

	public void DestroySelf(){
        Destroy(gameObject, 0.1f);
	}
}
