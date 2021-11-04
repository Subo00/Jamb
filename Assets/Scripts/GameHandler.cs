using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameHandler : MonoBehaviour
{
    
    [SerializeField] Functions functions;
    
    [SerializeField] GameObject down;
    [SerializeField] GameObject up;
    [SerializeField] GameObject free;
    [SerializeField] GameObject call;
    [SerializeField] Button[] buttons; 
    [SerializeField] GameObject endScreen;
    public int[] column;
    private bool isCalled = false;
    private int numOfFunct = 17;
    private int numOfThrows;


    void Start()
    {
        endScreen.SetActive(false);
        column = new int[numOfFunct];
        numOfThrows = 3;
        Roll();
    }

    protected void OnEnable()
    {
        Tile.tileClicked += ResetAll;
    }

    protected void OnDisable()
    {
        Tile.tileClicked -= ResetAll;
    }

    void ResetAll()
    {
        Invoke("CheckEndGame",0.5f);
        
    
        functions.ResetDice();
        numOfThrows = 3;
        //reset buttons as well
        DissableButtons();
        EnableButtons();
        if(isCalled)
        {
            up.GetComponent<Column>().SetClickable();
            down.GetComponent<Column>().SetClickable();
            free.GetComponent<Column>().SetClickable();
        }
        call.GetComponent<Column>().SetClickable();
        isCalled = false;

        Roll();
    }

    
    public void DissableButtons()
    {
        for(int i = 0; i < numOfFunct; i++)
        {
            buttons[i].interactable = false; 
        }
    }

    public void EnableButtons()
    {
        for(int i = 0; i < numOfFunct; i++)
        {   
            if( !call.transform.GetChild(i).gameObject.GetComponent<Tile>().isSet)
            buttons[i].interactable = true;
        }
    }
    public void Roll()
    {
        if(numOfThrows > 0)
        {
            functions.RollAll();
            numOfThrows--;
            
 
            //UI stuff goes here 
            SetColumnValue();
            PrintStuff();

            if(isCalled)
            {}
            else if(numOfThrows == 1)
            {
                call.GetComponent<Column>().SetUnclickable();
                DissableButtons();
            }
            
        }
    }

    private void SetColumnValue()
    {
        
        for(int i = 0; i < 6; i++)
        {
            int value = functions.CountNumber(i+1);
            column[i] = value;
        }


        column[7] = functions.Minimum();

        column[8] = functions.Maximum();

        column[10] =  functions.Tris();

        column[11] = functions.Scale();

        column[12] = functions.Full();

        column[13] = functions.Poker();

        column[14] = functions.Yamb();

    }

    private void PrintStuff()
    {
        for(int i = 0; i < numOfFunct; i++)
        {
            down.transform.GetChild(i).gameObject.GetComponent<Tile>().ChangeValue(column[i]); //edit this please
            up.transform.GetChild(i).gameObject.GetComponent<Tile>().ChangeValue(column[i]); //edit this please
            free.transform.GetChild(i).gameObject.GetComponent<Tile>().ChangeValue(column[i]); //edit this please
            call.transform.GetChild(i).gameObject.GetComponent<Tile>().ChangeValue(column[i]); //edit this please
        }
    }

    public void callTile(int tile)
    {
        FindObjectOfType<AudioManager>().Play("Button");
        //disable all columns 
        up.GetComponent<Column>().SetUnclickable();
        down.GetComponent<Column>().SetUnclickable();
        free.GetComponent<Column>().SetUnclickable();
        call.GetComponent<Column>().SetUnclickable();
        //& call buttons
        DissableButtons();

        isCalled = true;
        //enable call[tile] if the user wants to set the value he/she got
        call.transform.GetChild(tile).gameObject.GetComponent<Tile>().Clickable();
    
    }

    private void CheckEndGame()
    {
        if(down.transform.GetChild(numOfFunct-1).gameObject.GetComponent<Tile>().isSet &&
           up.transform.GetChild(numOfFunct-1).gameObject.GetComponent<Tile>().isSet &&
           free.transform.GetChild(numOfFunct-1).gameObject.GetComponent<Tile>().isSet &&
           call.transform.GetChild(numOfFunct-1).gameObject.GetComponent<Tile>().isSet)
           endScreen.SetActive(true);

        
    }

    
}
