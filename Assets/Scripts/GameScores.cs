using UnityEngine;

public class GameScores : MonoBehaviour
{
    public static int maxDistance; // ������������ ���� ���������� �������
    public static int amountCoins; // ���������� ��������� �����
    public static int amountSavedNPC; // ���������� ��������� ���

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
        //Debug.Log( @$"����� �����_{amountCoins}");
    }

    public static void SumSavedNPC() 
    {
        amountSavedNPC++;
        
    }

}
