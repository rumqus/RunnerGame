using UnityEngine;
using UnityEngine.UI;

public class GameScores : MonoBehaviour
{
    public static int maxDistance; // максимальный путь пройденный игроком
    public static int amountCoins; // количество собранных монет
    public static int amountSavedNPC; // количество собранных нпс
    private Text savedNPC;
    private Text collectedMoney;

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

    public static void SumCoins()
    {
        amountCoins++;
        //Debug.Log( @$"всего монет_{amountCoins}");
    }

    public static void SumSavedNPC() 
    {
        amountSavedNPC++;
        
    }

}
