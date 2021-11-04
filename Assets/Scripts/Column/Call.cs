using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : Column
{
   
    void Start()
    {
        for(int i = 0; i < 17; i++) tile[i].Clickable();

        tile[num].NotClickable();
        tile[minMax].NotClickable();
        tile[fun].NotClickable();
        tile[glob].NotClickable();
    }

   
    public override void SetClickable()
    {
        for(int i = 0; i < 17; i++)
        {
            if(!tile[i].isSet)
            tile[i].Clickable();
        }

        tile[num].NotClickable();
        tile[minMax].NotClickable();
        tile[fun].NotClickable();
        tile[glob].NotClickable();
    }
    
    public override void CheckSum()
    {
         if(!tile[num].isSet) 
        {
            if(tile[0].isSet &&
               tile[1].isSet &&
               tile[2].isSet &&
               tile[3].isSet &&
               tile[4].isSet &&
               tile[5].isSet)
                SumOfNum();   
        }

        if(!tile[minMax].isSet)
        {
            if(tile[0].isSet &&
               tile[7].isSet &&
               tile[8].isSet)
               SumMinMax();
        }

        if(!tile[fun].isSet)
        {
            if(tile[10].isSet &&
               tile[11].isSet &&
               tile[12].isSet &&
               tile[13].isSet &&
               tile[14].isSet)
                SumOfFun();
        }
        
        if(!tile[glob].isSet)
        {
            if(tile[num].isSet &&
               tile[minMax].isSet &&
               tile[fun].isSet)
                SumOfSum();
        }
    }
}
