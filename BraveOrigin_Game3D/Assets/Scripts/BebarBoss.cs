using UnityEngine;
using System.Collections;

public class BebarBoss : MonoBehaviour {

    public int bebarAmount;
    public int bebarNum;
    public GameObject EndBebar;

	void Update () {
        if (bebarAmount <= bebarNum)
        {
            Effect();
            bebarNum = 0;
            Destroy(gameObject, 0.5f);
        }
	}

    void Effect()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(EndBebar, this.transform.position, this.transform.rotation);
        }
    }
}
