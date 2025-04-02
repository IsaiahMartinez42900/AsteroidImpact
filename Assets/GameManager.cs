using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public float gametimeElapsed = 0;
    public float gameDuration = 10;
    public bool GameOver = false;
    float Asteroiddirection = -0.5f;
    float Asteroidspeed = 1.15f;
    float xSpeed = -0.4f;
    public GameObject Asteroid;
    public TextMeshProUGUI resultText;
    

    
    void Start()
    {
        
    }

   
    void Update()
    {

        if (gametimeElapsed < gameDuration)
        {
            //asteroid moving
            transform.Translate(xSpeed * Time.deltaTime, Asteroidspeed * Time.deltaTime * Asteroiddirection, 0);
            gametimeElapsed += Time.deltaTime;
        }
        else
        {
            //explosion animation
            GameOver = true;
            if (score < 9)
            {
                //if (resultText != null)
                //{
                resultText.text = "You Lose";
                Debug.Log("You lose");
           // }
            }
            
        }
        if (score == 9 && !GameOver)
        {
           // if (resultText != null)
           // {

            
            GameOver = true;
            resultText.text = "You Win";
            Debug.Log("You Win");
      //  }
        }
    }
}
