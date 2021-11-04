using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Column
{
    public int clickedIndex = 14;

    private void Start()
    {
        tile[14].Clickable();
    }

    public override void CheckSum()
    {
        if(clickedIndex == glob)
        return;
        if(tile[clickedIndex].isSet)
        {
            if(clickedIndex == 10)
            {
                SumOfFun();
                clickedIndex--;
            }
            else if(clickedIndex == 7)
            {
                clickedIndex--; //skips the min&max, beacuse you need ones
            }
            else if(clickedIndex == 0)
            {
                SumMinMax();
                SumOfNum();
                SumOfSum();
                clickedIndex = glob;
                return;
            }
            clickedIndex--;
            tile[clickedIndex].Clickable();
        }
    }

    public override void SetClickable()
    {
        if(clickedIndex != glob)
        tile[clickedIndex].Clickable();
    }
}
