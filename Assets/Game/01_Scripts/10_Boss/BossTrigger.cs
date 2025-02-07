using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    private Boss boss;

    private void Awake()
    {
        boss = GetComponentInParent<Boss>();
    }

    public void AnimationTrigger() => boss.AnimationTrigger();

}
