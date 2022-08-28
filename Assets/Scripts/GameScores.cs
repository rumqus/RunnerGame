using UnityEngine;
using System;
using UnityEngine.UI;

public class GameScores : MonoBehaviour
{
    public static int maxDistance; // максимальный путь пройденный игроком
    public static int amountCoins; // количество собранных монет
    public static int amountSavedNPC; // количество собранных нпс
    [SerializeField] private Text savedNPC;
    [SerializeField] private Text collectedMoney;
    [SerializeField] private Text walkDistance;

    private void OnEnable()
    {
        Actions.countCoins += SumCoins;
        Actions.countNPC += SumSavedNPC;
    }
    private void OnDisable()
    {
        Actions.countCoins -= SumCoins;
        Actions.countNPC -= SumSavedNPC;
    }

    private void Update()
    {
        savedNPC.text = amountSavedNPC.ToString();
        collectedMoney.text = amountCoins.ToString();
        walkDistance.text = maxDistance.ToString();
    }
    public static void SumCoins()
    {
        amountCoins++;        
    }
    public static void SumSavedNPC() 
    {
        amountSavedNPC++;        
    }

    public static void SumDistance() 
    {
        maxDistance++;    
    }

}
