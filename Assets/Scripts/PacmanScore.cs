
using TMPro;
using UnityEngine;

public class PacmanScore : MonoBehaviour
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
            TAccessor<PacmanScore>.Instance.AddItem(this);
            Score = 0;
      }
    
      private void OnDestroy()
      {
            TAccessor<PacmanScore>.Instance.RemoveItem(this);
      }

   
}
