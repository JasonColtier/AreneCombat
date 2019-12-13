using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnnemiLife : LifeManager
{

    [SerializeField]
    public Image LifeBar;

    [HideInInspector]
    public GameController gameController;

    private Canvas canvasLife;

    public void Start()
    {
        base.Start();

        canvasLife = LifeBar.GetComponentInParent<Canvas>();
        canvasLife.enabled = false;
    }

    public override void Death()
    {

        GetComponentInChildren<Animator>().SetTrigger("Death");
        GetComponent<NavMeshAgent>().isStopped = true;
        //GetComponent<BoxCollider>().enabled = false;
    }

    public override void End()
    {
        Destroy(gameObject);

        gameController.EnnemiKilled(gameObject);
    }

    public override void ChangeHealth(float modif)
    {
        canvasLife.enabled = true;
        Debug.Log("ennemi took dameges : " + modif);
        if(health > 0)
        {
            base.ChangeHealth(modif);
            LifeBar.transform.localScale = new Vector3(Mathf.Clamp(health / maxHealth,0,1), 1, 1);
        }
    }
}
