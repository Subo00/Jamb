using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dice : MonoBehaviour
{
    public int value;
    public bool canRoll = true;
    [SerializeField] Image spriteImage;
    [SerializeField] Image haloImage;
    [SerializeField] Sprite[] sprites = new Sprite[6];
    [SerializeField] Sprite[] rollAnimations = new Sprite[15];
    


    public void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        value = 1;
        canRoll = true;
        haloImage.enabled = !canRoll;
    }
    public void Roll()
    {
        if(canRoll) 
        {
            value = Random.Range(1,7);
            StartCoroutine("RollAnimation");
        }
       
    }


    public void Select()
    {
        canRoll = !canRoll;
        haloImage.sprite = sprites[value-1];
        haloImage.enabled = !canRoll;
        FindObjectOfType<AudioManager>().Play("Dice");
    }
    

    IEnumerator RollAnimation()
    {
        
        int numOfRolls = Random.Range(5,7);
        for (int i = 0; i < numOfRolls; i++) 
        {
            int temp = Random.Range(0,15);
            spriteImage.sprite = rollAnimations[temp];
            yield return new WaitForSeconds(0.1f);
        }
        
        spriteImage.sprite = sprites[value-1];
    }

}
