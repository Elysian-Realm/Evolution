using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Vector2 rolePosition;//��ɫ�ڵ�ǰ�����е�λ��

    //��¼������ĵ���(ֵΪtrueʱ)��[i,j,k]��ʾ��i���j�������еĵ�k�����ˣ���ҪΪÿ�����˵��������ô�1��ʼ�ĺ�׺
    public static bool[,,] enemyDestroyed = new bool[4, 4, 10];
    public static int[] mechaKilledNumber = new int[4];//ÿ���ۼƻ�ɱ���׵�������[i]��ʾ��i��
    public static int[] robotKilledNumber = new int[4];//ÿ���ۼƻ�ɱ�����˵�������[i]��ʾ��i��
    public static int level;//��ǰ����
    public static int room;//��ǰ�����
    //ÿ�������еĳ�ʼ������
    public static readonly int[,] mechaNumberMax = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 2, 3 }, { 0, 2, 3, 4 } };

    //ÿ�������е�ǰ������
    public static int[,] mechaNumber = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 1, 2, 3 }, { 0, 2, 3, 4 } };
    public static bool[] trigger1 = new bool[4];
    public static bool[] trigger2 = new bool[4];


    //���¿�ʼ�����ڴ��ĳ�ֽ��֮��������������
    public static void Restart()
    {
        Array.Clear(enemyDestroyed, 0, enemyDestroyed.Length);
        Array.Clear(mechaKilledNumber, 0, mechaKilledNumber.Length);
        Array.Clear(robotKilledNumber, 0, robotKilledNumber.Length);
        mechaNumber = (int[,])mechaNumberMax.Clone();
        Array.Clear(trigger2, 0, trigger2.Length);
        Array.Clear(trigger1, 0, trigger1.Length);
    }

    //���棬���ڽ�ɫ����֮�����õ�ǰ�����з��������
    public static void Replay()
    {
        Array.Clear(enemyDestroyed, 0, enemyDestroyed.Length);
        mechaKilledNumber[level] = robotKilledNumber[level] = 0;
        mechaNumber = (int[,])mechaNumberMax.Clone();
        Array.Clear(trigger2, 0, trigger2.Length);
    }
}
