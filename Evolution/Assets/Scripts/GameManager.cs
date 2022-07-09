using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Vector2 rolePosition;//角色在当前场景中的位置

    //记录被消灭的敌人(值为true时)，[i,j,k]表示第i层第j个房间中的第k个敌人，需要为每个敌人的名称设置从1开始的后缀
    public static bool[,,] enemyDestroyed = new bool[4, 4, 10];
    public static int[] mechaKilledNumber = new int[4];//每层累计击杀机甲的数量，[i]表示第i层
    public static int[] robotKilledNumber = new int[4];//每层累计击杀机器人的数量，[i]表示第i层
    public static int level;//当前层数
    public static int room;//当前房间号
    //每个房间中的初始机甲数
    public static readonly int[,] mechaNumberMax = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 2, 3 }, { 0, 2, 3, 4 } };

    //每个房间中当前机甲数
    public static int[,] mechaNumber = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 2, 3 }, { 0, 2, 3, 4 } };
    public static bool[] trigger1 = new bool[4];
    public static bool[] trigger2 = new bool[4];


    //重新开始，用于达成某种结局之后，重置所有数据
    public static void Restart()
    {
        Array.Clear(enemyDestroyed, 0, enemyDestroyed.Length);
        Array.Clear(mechaKilledNumber, 0, mechaKilledNumber.Length);
        Array.Clear(robotKilledNumber, 0, robotKilledNumber.Length);
        mechaNumber = (int[,])mechaNumberMax.Clone();
        Array.Clear(trigger2, 0, trigger2.Length);
        Array.Clear(trigger1, 0, trigger1.Length);
    }

    //重玩，用于角色死亡之后，重置当前层所有房间的数据
    public static void Replay()
    {
        Array.Clear(enemyDestroyed, 0, enemyDestroyed.Length);
        mechaKilledNumber[level] = robotKilledNumber[level] = 0;
        mechaNumber = (int[,])mechaNumberMax.Clone();
        Array.Clear(trigger2, 0, trigger2.Length);
    }
}
