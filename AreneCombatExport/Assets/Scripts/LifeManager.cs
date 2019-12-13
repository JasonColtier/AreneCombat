using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeManager : MonoBehaviour
{
    [SerializeField]
    protected float health;

    [SerializeField]
    protected int maxHealth;


    // Start is called before the first frame update
    public virtual void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void ChangeHealth(float modif)
    {
        health -= modif;


        if(health <= 0)
        {
            Death();
        }

    }

    public abstract void Death();

    public abstract void End();
}
