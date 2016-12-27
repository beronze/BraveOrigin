using UnityEngine;
using System.Collections;

public class Atk_hit : StateMachineBehaviour {

    public enum OwnerType
    {
        Player,
        Player_Skill,
        G_Warrior,
        G_Warrior_Boss,
        G_Warrior_Boss_Skill,
        G_Templar,
        G_Templar_Boss,
        G_Templar_Boss_Skill,
        G_Archer,
        G_King,
        G_King_Skill
    }

    public OwnerType Owner;


    public bool TwoEffect;

    public void OnStateEnter()
    {
        if (Owner == OwnerType.Player)
        {
            PlayerController _P_Con = GameObject.Find("Player").GetComponent<PlayerController>();

        }
        else if (Owner == OwnerType.Player_Skill)
        {
            PlayerController _P_Con = GameObject.Find("Player").GetComponent<PlayerController>();
            if (TwoEffect)
                _P_Con.NumberSkillUse = 3;
            _P_Con.TakeDamage();
        }
        else if (Owner == OwnerType.G_Warrior)
        {
            NaveMeshEnemy _E_Sta = GameObject.Find("G_Warrior").GetComponent<NaveMeshEnemy>();
            _E_Sta.Atk();
        }
        else if (Owner == OwnerType.G_Warrior_Boss)
        {
            BossAI _E_Sta = GameObject.Find("G_Warrior_Boss").GetComponent<BossAI>();
            _E_Sta.Atk();
        }
        else if (Owner == OwnerType.G_Warrior_Boss_Skill)
        {
            BossAI _E_Sta = GameObject.Find("G_Warrior_Boss").GetComponent<BossAI>();
            _E_Sta.TakeDamage();
        }
        else if (Owner == OwnerType.G_Templar)
        {
            NaveMeshEnemy _E_Sta = GameObject.Find("G_Templar").GetComponent<NaveMeshEnemy>();
            _E_Sta.Atk();
        }
        else if (Owner == OwnerType.G_Templar_Boss)
        {
            BossAI _E_Sta = GameObject.Find("G_Templar_Boss").GetComponent<BossAI>();
            _E_Sta.Atk();
        }
        else if (Owner == OwnerType.G_Templar_Boss_Skill)
        {
            BossAI _E_Sta = GameObject.Find("G_Templar_Boss").GetComponent<BossAI>();
            _E_Sta.TakeDamage();
        }
        else if (Owner == OwnerType.G_King)
        {
            BossAI _E_Sta = GameObject.Find("King_Goblin").GetComponent<BossAI>();
            _E_Sta.Atk();
        }
        else if (Owner == OwnerType.G_King_Skill)
        {
            BossAI _E_Sta = GameObject.Find("King_Goblin").GetComponent<BossAI>();
            if (TwoEffect)
                _E_Sta.NumberSkillUse = 2;
            _E_Sta.TakeDamage();

        }
        

    }
}
