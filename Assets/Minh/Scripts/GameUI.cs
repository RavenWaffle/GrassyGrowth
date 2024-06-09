using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI blockFilled, blockMax, wave, resource;
    private float timeCounter;

    private TilesManager tilesManager;

    private PlayerResource playerResource;

    [SerializeField] private Image wood, water;
    // Start is called before the first frame update
    void Start()
    {
        tilesManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TilesManager>();
        playerResource = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResource>();
        timeCounter = tilesManager.timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        blockFilled.text = tilesManager.grassTiles.Count.ToString();
        blockMax.text = tilesManager.tileList.Count.ToString();
        if (tilesManager.countdownWave)
        {
            timeCounter -= Time.deltaTime;
            wave.text = "Wave coming in " + (Mathf.RoundToInt(timeCounter)).ToString();
        }
        else
        {
            wave.text = "Wave " + tilesManager.currentWave.ToString() + "\n Enemies left: " + tilesManager.enemiesToKill;
            timeCounter = tilesManager.timeLeft;
        }

        if (playerResource.usingWater)
        {
            wood.enabled = false;
            water.enabled = true;
            resource.text = playerResource.currentWaterResource.ToString() + " / " + playerResource.requiredWaterResource;
        }
        else
        {
            water.enabled = false;
            wood.enabled = true;
            resource.text = playerResource.currentSeedResource.ToString() + " / " + playerResource.requiredSeedResource;
        }
    }
}
