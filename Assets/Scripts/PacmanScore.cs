
using TMPro;
using UnityEngine;

//score management and display of pacmans
public class PacmanScore : MonoBehaviour
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
            TAccessor<PacmanScore>.Instance.AddItem(this);
            Score = 0;
      }
    
      private void OnDestroy()
      {
            TAccessor<PacmanScore>.Instance.RemoveItem(this);
      }

   
}
