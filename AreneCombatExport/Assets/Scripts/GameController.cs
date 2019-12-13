using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private MovePlayer player;

    [SerializeField]
    private GameObject ennemiPrefab;

    [SerializeField]
    private GameObject ennemiPrefabBig;

    [SerializeField]
    private GameObject ennemiPrefabFast;

    [SerializeField]
    private int nbEnnemis = 10;

    [Range(0,10)]
    [SerializeField]
    private int probaWarriorFast;

    [SerializeField]
    private int numberOfWaves = 5;

    [SerializeField]
    private int delayBetweenWaves = 6;

    [SerializeField]
    private float ennemiMultiplyerPerWave = 1.5f;

    [SerializeField]
    private float spawnrate;

    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();



    [SerializeField]
    private  List<GameObject> prefabWeaponsList = new List<GameObject>();

    [SerializeField]
    private Transform weaponSpawnPoint;


    [Header("UI")]
    [SerializeField]
    private Text waveUI;

    [SerializeField]
    private Text scoreUI;

    [SerializeField]
    private GameObject deathScreenParent;

    [SerializeField]
    private GameObject victoryScreen;


    private int originalNbEnnemies;
    private int currentWave = 1;
    private int score = 0;

    private float time;

    private float timerDelayBetweenWaves;

    private bool spawnWave = true;
    private bool playerIsDead = false;

    private bool hasDroppedAWeapon = false;


    public List<GameObject> ennemiesAliveList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        originalNbEnnemies = nbEnnemis;

        UpdateWaveUI();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time> spawnrate && spawnWave && currentWave <= numberOfWaves)
        {
            Vector3 pos = spawnPoints[Random.Range(0,spawnPoints.Count - 1)].position;

            GameObject monEnnemi = null;
            if(currentWave > 1 && nbEnnemis <= currentWave -1)
            {
                monEnnemi = Instantiate(ennemiPrefabBig, pos, Quaternion.identity);
            }
            else
            {
                if (Random.Range(0, 10) < probaWarriorFast)
                {
                    monEnnemi = Instantiate(ennemiPrefabFast, pos, Quaternion.identity);
                }
                else {
                    monEnnemi = Instantiate(ennemiPrefab, pos, Quaternion.identity);
                }
            }
            monEnnemi.GetComponent<WarriorController>().target = player.transform;
            monEnnemi.GetComponent<EnnemiLife>().gameController = this;
            ennemiesAliveList.Add(monEnnemi);
            time = 0;
            nbEnnemis--;

            if (nbEnnemis == 0 )
            {
                spawnWave = false;   
            }
        }

        if (ennemiesAliveList.Count == 0 && !spawnWave)
        {
            if(currentWave >= numberOfWaves)
            {
                Victory();
                return;
            }

            DropWeapon();
            timerDelayBetweenWaves += Time.deltaTime;
            if(timerDelayBetweenWaves > delayBetweenWaves){
                hasDroppedAWeapon = false;
                timerDelayBetweenWaves = 0;
                spawnWave = true;
                nbEnnemis += Mathf.RoundToInt(originalNbEnnemies * ennemiMultiplyerPerWave);
                ennemiMultiplyerPerWave *= 2;
                currentWave++;
                UpdateWaveUI();
            }

           
        }

        if (playerIsDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    public void DropWeapon(){
        if(!hasDroppedAWeapon){
            if(prefabWeaponsList.Count != 0)
            {
                hasDroppedAWeapon = true;
                int i = Random.Range(0, prefabWeaponsList.Count);
                GameObject weapon = Instantiate(prefabWeaponsList[i], weaponSpawnPoint.position, Quaternion.identity);
                prefabWeaponsList.RemoveAt(i);
            }
        }
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
    }

    public void EnnemiKilled(GameObject gameObject)
    {
        ennemiesAliveList.Remove(gameObject);
        score++;
        scoreUI.text = "Score : " + score;

    }

    public void PlayerDeath()
    {
        deathScreenParent.SetActive(true);
        playerIsDead = true;
    }

    public void UpdateWaveUI()
    {
        waveUI.text = "Vague " + currentWave + " / " + numberOfWaves;
    }

}
