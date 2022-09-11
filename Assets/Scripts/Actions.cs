using UnityEngine;
using System;

public class Actions : MonoBehaviour
{
    public static Action addNPC; // делегат добавляющий npc в цепочку игрока
    public static Action countCoins; // делегат для подсчета монет
    public static Action countNPC; // делегат подсчета собранных нпс
    public static Action startAnimation; // делегат для запуска стартовой анимации idle
    public static Action startDeathAnimaion; // делегат для запуска анимации смерти
    public static Action IncreaseSpeed; // увеличиваем скорость
    public static Action trimChainNPC; // делегат для удаления лишних npc
    
}
