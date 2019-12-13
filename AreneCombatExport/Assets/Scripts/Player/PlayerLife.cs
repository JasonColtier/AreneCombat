using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : LifeManager
{

    [Header("UI")]
    [SerializeField]
    private GameObject prefabHeart;

    [SerializeField]
    private GameObject canvasPlayerHealthContainer;

    [SerializeField]
    private float invulnerabilityTime;

    public List<GameObject> heartList = new List<GameObject>();

    private AudioSource audioSource;

    private float timer;

    private bool hasTakenDamage;

    private void Start()
    {
        base.Start();

        audioSource = GetComponent<AudioSource>();


        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate<GameObject>(prefabHeart, canvasPlayerHealthContainer.transform);
            heartList.Add(heart);
            heart.transform.localPosition = new Vector3(75 * i, 0, 0);
        }
    }

    private void Update()
    {
        if (hasTakenDamage)
        {
            timer += Time.deltaTime;
            if(timer > invulnerabilityTime)
            {
                timer = 0;
                hasTakenDamage = false;
            }
        }
    }

    public override void ChangeHealth(float modif)
    {
        if (health > 0 && hasTakenDamage == false)
        {
            base.ChangeHealth(modif);

            hasTakenDamage = true;

            audioSource.Play();

            if (modif < 0)
            {
                heartList[(int)health].GetComponent<changeImageHeart>().Heal();

            }
            else if(modif > 0)
            {
                heartList[(int)health].GetComponent<changeImageHeart>().TakeDamage();

            }
        }
    }

    public override void Death()
    {
        GameObject.Find("GameController").GetComponent<GameController>().PlayerDeath();
        gameObject.GetComponent<MovePlayer>().isDead = true;
        gameObject.GetComponent<WeaponController>().DisableWeapon();
    }

    public override void End()
    {

        //
    }
}
