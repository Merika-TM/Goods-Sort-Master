using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int items;

    [SerializeField] private float timeRemaining;
    [SerializeField] private TextMeshProUGUI timerText;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
            
            if (timeRemaining <= 0)
            {
                // TODO: When the timer runs out, the loss operation is performed
                Lose();
            }
        }
    }

    private void DisplayTime(float timeDoDisplay)
    {
        timeDoDisplay += 1;
        float minutes = Mathf.FloorToInt(timeDoDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDoDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CheckedGameState()
    {
        items -= 1;

        if (items == 0)
        {
            // TODO: When the items are answered, an item is deleted and the winning operation begins
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("You are win...");
    }

    private void Lose()
    {
        Debug.Log("Sorry You Lose!");
    }
}
