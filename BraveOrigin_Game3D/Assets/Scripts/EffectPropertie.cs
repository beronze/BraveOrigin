using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EffectPropertie : MonoBehaviour {


	public float Speed;
	public bool IsRage;

	public float PureDamage, PercentDamage;
	public GameObject _TextDamage;

    public float Delay_Dtroy;

    public enum OwnerType
	{
		Player,
		Enemy
	}

	public OwnerType Owner;

	void Start () {
        Destroy(gameObject, Delay_Dtroy);

    }
	

	void Update () {
  
		if (IsRage) 
		{
            transform.Translate(0, 0, Speed * Time.deltaTime);
		}
        
	}

    
    void OnTriggerEnter(Collider other)
    {
        float DamageHP;
        if (other.gameObject.tag == "Enemy" && Owner == OwnerType.Player)
        {
            EnemyStatus estat = other.gameObject.GetComponent<EnemyStatus>();
            DamageHP = (CalculateDamage() - estat.Def);
            if (DamageHP <= 1)
                DamageHP = 1;            
            estat.CurrentHp -= DamageHP;
            DrawText(DamageHP, other.transform.position);
        }

        if (other.gameObject.tag == "Player" && Owner == OwnerType.Enemy)
        {
           
            PlayerStatus pstat = other.gameObject.GetComponent<PlayerStatus>();
            DamageHP = (CalculateDamage() - (pstat.Def + pstat.item_Def)); 
            if (DamageHP <= 1)
                DamageHP = 1;             
            pstat.CurrentHp -= DamageHP;
            DrawText(DamageHP, other.transform.position);
        }

        
        if (other.gameObject.tag == "Map" && this.tag == "ATKSkill")
        {
            Speed *= -0.8f;
            Destroy(gameObject, 0.5f);      
        }

    }


	public float CalculateDamage()
	{
		float damage = PureDamage * PercentDamage/100;
        return Random.Range(damage - damage * 10 / 100, damage + damage * 10 / 100);

	}
    
	public void DrawText(float damage, Vector3 pos)
	{
        GameObject thistext = Instantiate(_TextDamage, pos + new Vector3(Random.Range(-1f, 1f), 20, 
            Random.Range(-1f, 1f)), _TextDamage.transform.rotation) as GameObject;

        if (thistext != null)
        {
            thistext.transform.GetChild(0).GetComponent<Text>().text = Owner == OwnerType.Player ?
                "<color=#ffaa00>" + (Mathf.Abs(damage)).ToString("#,###,###,###") + "</color>" :
                "<color=#ff0000>" + (Mathf.Abs(damage)).ToString("#,###,###,###") + "</color>";

            thistext.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), 100, Random.Range(-10f, 10f)));

        }
	}
}
