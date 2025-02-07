using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitBossUI());
    }

    IEnumerator WaitBossUI()
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
}
