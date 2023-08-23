using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    private int amountOfHarvestAlreadyHarvested; // количество уже собраного урожая
    [SerializeField] private static int _numberOfStagesOfMaturationOfBed; // количество стадий созревания грядки
    [SerializeField] private int currentStageMaturation; // ткущая стадия созревания 
    [SerializeField] private int cropQuantity; // количество урожая

    [SerializeField] protected Sprite[] displayingStagesMaturation; // отображение стадий созревания 
    protected SpriteRenderer gameObjectSprite;

    [SerializeField] private float timeToMaturity; //время до созревания 
    [SerializeField] private float timerUntilMaturation; // таймер до озревания 

    [SerializeField] private bool harvestIsRipe; // урожай созрел

    [SerializeField] private GameObject harvest; // урожай

    private void Awake()
    {
        gameObjectSprite = GetComponent<SpriteRenderer>();
        _numberOfStagesOfMaturationOfBed = displayingStagesMaturation.Length-1;
    }
    private void FixedUpdate()
    {
        HarvestHasGrown();
    }

    private float Topwatch(float _time)
    {
        return _time -= Time.deltaTime;
    }

    private void HarvestHasGrown() // урожай вырос
    {
        if (harvestIsRipe) return;

        if(timerUntilMaturation > 0) timerUntilMaturation -= Time.deltaTime;
        
        if(timerUntilMaturation<=0)
        {
            currentStageMaturation++;
            timerUntilMaturation = timeToMaturity;

            if (currentStageMaturation <= _numberOfStagesOfMaturationOfBed) gameObjectSprite.sprite = displayingStagesMaturation[currentStageMaturation];
            
            if(currentStageMaturation == _numberOfStagesOfMaturationOfBed)
            {
                harvestIsRipe = true;// урожай созрел
            }
            return;
        }
    }

    public void Harvesting() // сбор урожая
    {
        Debug.Log("!");
        if(harvestIsRipe == true)
        {
            for (int i = 0; i < cropQuantity; i++)
            {
                Instantiate(harvest, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            harvestIsRipe = false;
        }
    }
}
