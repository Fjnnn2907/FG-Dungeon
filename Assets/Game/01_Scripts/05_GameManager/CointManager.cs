using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointManager : MonoBehaviour
{
    [SerializeField] protected int coint;
    [SerializeField] protected int diamond;
    public int TakeCoint() => coint;
    public int TakeDiamond() => diamond;
    public void AddCoint(int _coint)
    {
        coint += _coint;

        Obsever.Notify("UpdateCoint");
    }

    public void AddDiamond(int _diamond)
    {
        diamond += _diamond;

        Obsever.Notify("UpdateCoint");
    }

    public void RemoveCoint(int _coint)
    {
        if(coint < _coint) return;

        coint -= _coint;

        Obsever.Notify("UpdateCoint");
    }

    public void RemoveDiamond(int _diamond)
    {
        if (diamond < _diamond) return;

        diamond -= _diamond;

        Obsever.Notify("UpdateCoint");
    }
}
