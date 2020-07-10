using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//score management and display of ghosts
public class GhostScore : MonoBehaviour
{   
    
    private int score = 0;
    public TextMeshProUGUI text;

    //property that updates the UI and score
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
