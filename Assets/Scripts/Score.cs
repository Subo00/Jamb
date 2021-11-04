using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI  label;
    protected void OnEnable()
    {
        Column.sumSet += UpdateScore;
    }

    protected void OnDisable()
    {
        Column.sumSet -= UpdateScore;
    }
    private void UpdateScore(int sum)
    {
        score += sum;
        label.text = score.ToString();
    }
}
