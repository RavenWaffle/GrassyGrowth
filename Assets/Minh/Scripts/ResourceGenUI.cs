using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceGenUI : MonoBehaviour
{
    [SerializeField] private float timeToGen;
    [SerializeField] protected Slider timeToGenSlider;

    private ResourceGen resourceGen;
    // Start is called before the first frame update
    void Start()
    {
        resourceGen = this.GetComponent<ResourceGen>();
        timeToGen = resourceGen.timeToSpawns;
        if (timeToGenSlider != null) timeToGenSlider.maxValue = timeToGen;
        if (timeToGenSlider != null) timeToGenSlider.maxValue = resourceGen.timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        timeToGen = resourceGen.timeToSpawns;
        //Debug.Log(timeToGen);
        if (timeToGenSlider != null) timeToGenSlider.value = Mathf.Lerp(timeToGenSlider.value, timeToGen, Time.deltaTime * 6);
    }
}
