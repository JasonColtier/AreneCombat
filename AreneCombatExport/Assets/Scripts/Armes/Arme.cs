using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arme : MonoBehaviour
{

    [HideInInspector]
    public int munitions;

    [HideInInspector]
    public WeaponController weaponController;

    [SerializeField]
    public int maxMunitions;

    [SerializeField]
    protected float fireRate;

    [SerializeField]
    protected float bulletSpeed;

    [SerializeField]
    protected float damage;

    [SerializeField]
    protected int bulletsPerShot;

    [SerializeField]
    protected float bulletLife;

    [SerializeField]
    protected float reloadSpeed;

    [SerializeField]
    protected AudioClip gunsound;

    [SerializeField]
    public GameObject lightEffect;


    private float time;

    private float time2;

    private AudioSource audioSource;

    private bool startReload;

    private bool canFire;

    public bool isCurrentWeapon = false;

    public bool isOnTheGround = true;

    public enum WeaponsEnum { Pistol, Shotgun, Sniper,Riffle };
    [SerializeField]
    public WeaponsEnum weaponsEnum;

    // Start is called before the first frame update
    void Start()
    {
        munitions = maxMunitions;
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = gunsound;
        time2 = fireRate;
    }

    void Update()
    {
        if (startReload)
        {
            time += Time.deltaTime;
            
            if(time >= reloadSpeed)
            {
                time = 0;
                startReload = false;
                Reload();
            }
        }

        if (Input.GetMouseButton(0))
        {
            time2 += Time.deltaTime;
            if (time2 > fireRate && munitions > 0)
            {
                time2 = 0;
                if (isCurrentWeapon)
                {
                    Fire();
                }
            }
        }

        if(isOnTheGround){
            transform.Rotate(new Vector3(0,1,0));
        }
    }

    public virtual void Fire()
    {
       
        munitions -= bulletsPerShot;
        audioSource.Play();
        weaponController.UpdateWeaponUI(munitions,maxMunitions);

        if (munitions <= 0)
        {
            startReload = true;
        }
    }

    public virtual void Reload()
    {
        munitions = maxMunitions;
    }

   
}
