using UnityEngine;
using System;

public class Actions : MonoBehaviour
{
    public static Action addNPC; // делегат добавляющий npc в цепочку игрока
    public static Action countCoins; // делегат для подсчета монет
    public static Action countNPC; // делегат подсчета собранных нпс
    public static Action generateLocation; // делегат генерации уровню

}
