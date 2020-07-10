using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GhostScore : MonoBehaviour
{   
    
    private int score = 0;
    public TextMeshProUGUI text;

    public int Score
    {
        get => score;
        set
        { 
            score = value;
            text.text = gameObject.name+ " : " + score.ToString();
        }
    }
    private void Awake()
    {
        TAccessor<GhostScore>.Instance.AddItem(this);
        Score = 0;
    }

    private void OnDestroy()
    {
        TAccessor<GhostScore>.Instance.RemoveItem(this);
    }

}
