using UnityEngine;
using System.Collections;

public class BtmChangeSce : MonoBehaviour {



    public void ChageScene(string scenename)
    {
        SaveGame SG = GameObject.Find("DataCenter").GetComponent<SaveGame>();
        SG.AutoSave();

        StartCoroutine(WaitForSeconds(scenename));

    }

    public void SceneAgain()
    {
        SaveGame SG = GameObject.Find("DataCenter").GetComponent<SaveGame>();
        SG.AutoSave();

        StartCoroutine(WaitForSeconds(Application.loadedLevelName));

    }


    IEnumerator WaitForSeconds(string scene)
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.50f);
        
        Application.LoadLevel(scene);

    }
}
