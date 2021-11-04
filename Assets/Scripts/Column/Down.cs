using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Column
{
    public int clickedIndex = 0;
    void Start()
    {
        tile[0].Clickable();
    }

    public override void CheckSum()
    {
        if(clickedIndex == glob)
        return;
        if(tile[clickedIndex].isSet)
        {
            if(clickedIndex == 5)
            {
                SumOfNum();
                clickedIndex++;
            }
            else if(clickedIndex == 8)
            {
                SumMinMax();
                clickedIndex++; 
            }
            else if(clickedIndex == 14)
            {
                SumOfFun();
                clickedIndex++; 
                
                SumOfSum();
                clickedIndex++; 
                
                return;
            }
            clickedIndex++;
            tile[clickedIndex].Clickable();
        }
    }

    public override void SetClickable()
    {
        if(clickedIndex != glob)
        tile[clickedIndex].Clickable();
    
    }
}
