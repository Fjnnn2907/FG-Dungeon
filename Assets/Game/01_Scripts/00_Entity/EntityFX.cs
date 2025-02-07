using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash Fx")]
    [SerializeField] private Material HitMaterial;
    private Material OriginalMaterial;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        OriginalMaterial = sr.material;
    }

    private IEnumerator HitFlashFx()
    {
        sr.material = HitMaterial;
        Color currentColor = sr.color;
        sr.color = Color.white;

        yield return new WaitForSeconds(.2f);

        sr.color = currentColor;
        sr.material = OriginalMaterial;
    }
}
