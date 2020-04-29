using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health 
    { 
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }

    public override void Init()
    {
        base.Init();
    }
}
