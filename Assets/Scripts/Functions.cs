using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    
    private static int numOfDice = 6;
    [SerializeField] public Dice[] dice = new Dice[numOfDice];
    private int[] duplication = new int[numOfDice];
    private int bonusTris = 20;
    private int bonusFull = 30;
    private int bonusPoker = 40;
    private int bonusYamb = 50;


    public void RollAll()
    {
        for(int i = 0; i < numOfDice; i++)
        dice[i].Roll();

        FindDuplicate();
    }

    public void ResetDice()
    {
        for(int i = 0; i < numOfDice; i++)
        {
            dice[i].Reset();
        }
    }



    public int CountNumber(int numToCount)
    {
        int temp = duplication[numToCount-1];
        if(temp == 6)
        temp--;

        return temp * numToCount;
    }

    public int Minimum()
    {
        int rMin = 0;
        int max = 0;

        for(int i = 0; i < numOfDice; i++)
        {
            if(dice[i].value > max)
            max = dice[i].value;

            rMin += dice[i].value;
        }
        rMin -= max;

        return rMin;
    }

    public int Maximum()
    {
        int rMax = 0;
        int min = 7;

        for(int i = 0; i < numOfDice; i++)
        {
            if(dice[i].value < min)
            min = dice[i].value;

            rMax += dice[i].value;
        }
        rMax -= min;

        return rMax;
    }

    public void FindDuplicate()
    {
        for(int i = 0; i < numOfDice; i++)
        duplication[i] = 0;

        for(int i = 0; i < numOfDice; i++)
        {
            int tmp = dice[i].value - 1;
            duplication[tmp]++;
        }
    }

    public int Scale()
    {
        if(duplication[1] > 0 && 
           duplication[2] > 0 && 
           duplication[3] > 0 && 
           duplication[4] > 0)
           {
                if(duplication[5] > 0)
                return 40;

                if(duplication[0] > 0)
                return 30;   
           }

        return 0;
    }

    public int Tris()
    {
        for(int i = numOfDice-1; i > 0; i--)
        {
            if(duplication[i] >= 3)
            return ((i+1)*3 + bonusTris);
        }
        return 0;
    }

    public int Poker()
    {
        for(int i = 0; i < numOfDice; i++)
        {
            if(duplication[i] >= 4)
            return ((i+1)*4 + bonusPoker);
        }
        return 0;
    }

    public int Yamb()
    {
        for(int i = 0; i < numOfDice; i++)
        {
            if(duplication[i] >= 5)
            return ((i+1)*5 + bonusYamb);
        }
        return 0;
    }

    public int Full()
    {
        int three = -1;
        for(int i = numOfDice-1; i > 0; i--)
        {
            if(duplication[i] >= 3)
            {
                three = i;
                break;
            }
        }

        if(three != -1)
        for(int i = 0; i < numOfDice; i++)
        {
            if(duplication[i] >= 2 && i != three)
            return ((i+1)*2 + (three+1)*3 + bonusFull);
        }

        return 0;
    }
}
