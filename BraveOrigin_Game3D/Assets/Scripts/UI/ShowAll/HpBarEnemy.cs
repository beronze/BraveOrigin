using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBarEnemy : MonoBehaviour {

    public Image Fill;
    EnemyStatus _enemyStatus;
    private Camera m_Camera;

    void Start () {
        m_Camera = Camera.main;
		_enemyStatus = transform.parent.GetComponent<EnemyStatus> ();
	}
	
	void Update () {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
        if (_enemyStatus != null)
        {
            Fill.fillAmount = _enemyStatus.CurrentHp / _enemyStatus.MaxHp;

        }
    }
}
