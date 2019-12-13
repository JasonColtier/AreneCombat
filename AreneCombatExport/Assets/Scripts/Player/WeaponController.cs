using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    //private List<GameObject> weapons = new List<GameObject>();

    [SerializeField]
    private GameObject startingWeapon;

    [SerializeField]
    private Transform weaponHolder;

    public GameObject currentWeapon;

    public List<GameObject> weaponsHoldedList = new List<GameObject>();

    [Header("UI")]
    [SerializeField]
    private Text weaponNameUI;

    [SerializeField]
    private Text munitionUI;

    // Start is called before the first frame update
    void Start()
    {
        //currentWeapon = startingWeapon;
        startingWeapon.SetActive(true);

        PickupWeapon(startingWeapon);
;
    }

    private void Update()
    {
        Vector2 scroll = Input.mouseScrollDelta;
        if (scroll.y > 0)
        {
            SwitchWeapon(1);
        }
        if (scroll.y < 0)
        {
            SwitchWeapon(-1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arme")
        {
            Debug.Log("arme");

            currentWeapon.SetActive(false);

            PickupWeapon(other.gameObject);

        }
    }

    public void PickupWeapon(GameObject weapon)
    {
        weaponsHoldedList.Add(weapon);
        currentWeapon = weapon;

        weapon.transform.parent = weaponHolder.transform;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        Destroy(weapon.GetComponent<Rigidbody>());

        Arme armeScript = currentWeapon.GetComponent<Arme>();
        armeScript.isCurrentWeapon = true;
        armeScript.weaponController = this;
        armeScript.isOnTheGround = false;
        armeScript.lightEffect.SetActive(false);

        weaponNameUI.text = armeScript.weaponsEnum.ToString();

        UpdateWeaponUI(armeScript.maxMunitions, armeScript.maxMunitions);
    }

    public void UpdateWeaponUI(int munitionRemaining,int maxMun)
    {
        munitionUI.text = munitionRemaining + " / " + maxMun;
    }

    public void DisableWeapon()
    {
        currentWeapon.GetComponent<Arme>().isCurrentWeapon = false;
        //et empecher changement arme
    }

    public void SwitchWeapon(int direction)
    {
        int i = weaponsHoldedList.IndexOf(currentWeapon);
        currentWeapon.SetActive(false);

        if(direction > 0){
            if (i +2 <= weaponsHoldedList.Count)
            {
                currentWeapon = weaponsHoldedList[i + 1];
            }
            else
            {
                currentWeapon = weaponsHoldedList[0];
            }
        }else if(direction <0){
            if (i -1 >= 0)
            {
                currentWeapon = weaponsHoldedList[i -1];
            }
            else
            {
                currentWeapon = weaponsHoldedList[weaponsHoldedList.Count -1];
            }
        }

        
        currentWeapon.SetActive(true);
        Arme armeScript = currentWeapon.GetComponent<Arme>();
        armeScript.isCurrentWeapon = true;
        armeScript.weaponController = this;
        weaponNameUI.text = armeScript.weaponsEnum.ToString();

        UpdateWeaponUI(armeScript.maxMunitions, armeScript.maxMunitions);
    }
}
