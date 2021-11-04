using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    
    public Tile[] tile; 
    protected int num = 6;
    protected int minMax = 9;
    protected int fun = 15;
    protected int glob = 16;
    public static event Action<int> sumSet;

   
    protected void OnEnable()
    {
        Tile.tileClicked += CheckSum;
    }

    protected void OnDisable()
    {
        Tile.tileClicked -= CheckSum;
    }

    protected void SumOfNum()
    {
        int sum = 0;
                //1 - 6
        for (int i = 0; i < 6; i++)
        sum += tile[i].value;

        if(sum >= 60)
        sum += 30;

        tile[num].ChangeValue(sum);
        tile[num].Set();
        sumSet?.Invoke(sum);
    }

    protected void SumMinMax()
    {               //MAX           MIN             NumOfOnes
        int sum = (tile[8].value - tile[7].value) * tile[0].value;

        tile[minMax].ChangeValue(sum);
        tile[minMax].Set();
        sumSet?.Invoke(sum);
    }

    protected void SumOfFun()
    {
        int sum = 0;
        
        for(int i = 10; i < 15; i++)
        sum += tile[i].value;

        tile[fun].ChangeValue(sum);
        tile[fun].Set();
        sumSet?.Invoke(sum);
    }

    protected void SumOfSum()
    {     //sum of: numbers         min/max         functions
        int sum = tile[6].value + tile[9].value + tile[15].value;

        tile[glob].ChangeValue(sum);
        tile[glob].Set();
        sumSet?.Invoke(sum);
    }

    public virtual void CheckSum()
    {
        
    }

    public void SetUnclickable()
    {
        for (int i = 0; i < 17; i++)
        tile[i].NotClickable();
    }

    public virtual void SetClickable()
    {

    }
}
