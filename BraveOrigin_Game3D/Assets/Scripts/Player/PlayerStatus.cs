using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public float CurrentHp, MaxHp, CurrentMp, MaxMp, Damage, Def, Speed;
    public int item_Def, item_Damage, item_Speed, buff_Damage;
    public int Level, Exp, s_Str, s_Vit, s_Def, s_Point, Money;
    public string C_name,date;


    public int[] LevelExp = {31};



    void Start ()
    {
        
        CurrentLevel();

    }

    void FixedUpdate()
    {
        if (Exp >= LevelExp[30])
            Level = 30;
        else
        {
            for (int i = 0; i <= 30; i++)
            {
                if (Exp < LevelExp[i])
                {
                    Level = i;
                    break;
                }
            }
        }
        CalculateStatus();

    }



    public void CalculateStatus()
    {
        MaxHp = (s_Vit * 60);
        Damage = (s_Str * 2);
        Def = (s_Def * 1);

    }

    void CurrentLevel()
    {

        LevelExp[0] = 0;
        LevelExp[1] = 100;
        for (int i = 2; i <= 30; i++)
        {
            LevelExp[i] = LevelExp[i - 1] + 50 + (LevelExp[i - 1] - LevelExp[i - 2]); 
        }
       
    }

}
