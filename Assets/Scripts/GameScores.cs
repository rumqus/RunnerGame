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
        Actions.distance += SumDistance;
    }

    private void OnDisable()
    {
        Actions.countCoins -= SumCoins;
        Actions.countNPC -= SumSavedNPC;
        Actions.distance -= SumDistance;        
    }

    public static void SumDistance()
    {
        maxDistance = maxDistance + 5;
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

    public static void NullScore() 
    {
        maxDistance = 0;
        amountCoins = 0;
        amountSavedNPC = 0;
    }

    

}
