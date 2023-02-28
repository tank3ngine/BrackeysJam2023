using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawnerScript : MonoBehaviour
{
    private GameObject GM;
    private GameManager GMScript;

    [SerializeField] private GameObject[] SpawnLocations;
    [SerializeField] private GameObject baseCoinPrefab;

    [SerializeField] public float coinTimer;
    [SerializeField] public float coinSpawnInterval;



    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController");
        GMScript = GM.GetComponent<GameManager>();

        coinTimer = 3;
    }

    private void Update()
    {
        if (coinTimer > 0)
        {
            coinTimer -= Time.deltaTime;
        }
        else
        {
            calcCoin();
            coinTimer = coinSpawnInterval;
        }
    }

    public void calcCoin()
    {
        var locationPicker = Random.Range(0, SpawnLocations.Length);
        GameObject baseCoin = Instantiate(baseCoinPrefab, SpawnLocations[locationPicker].transform.position, Quaternion.identity, GMScript.coinHolder.transform);
        var tempCoinScript = baseCoin.GetComponent<coinScript>();

        float randomFloat = Random.Range(0f, 1f);

        if (randomFloat <= 0.55f)
        {
            baseCoin.tag = "BronzeCoin";
            return;
        }

        if (randomFloat <= 0.85f)
        {
            baseCoin.tag = "SilverCoin";

            return;
        }

        else
        {
            baseCoin.tag = "GoldCoin";
        }
    }
}
