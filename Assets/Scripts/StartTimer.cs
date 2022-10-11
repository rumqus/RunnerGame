using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float time;
    [SerializeField] private Text timerText;
    private float timeLeft = 0f;
    private bool timerOn = false;

    private void Start()
    {
        timeLeft = time;
        timerOn = true;
        player.GetComponent<Player>().enabled = false;
    }

    private void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                timeLeft = time;
                timerOn = false;
                Actions.startAnimation();
                Locations.locationSpeed = 15f;
            }
        }
    }

    private void UpdateTimeText()
    {
        if (timeLeft < 0) 
        {
            timerText.gameObject.SetActive(false);
            timeLeft = 0;
            Time.timeScale = 1f;
            player.GetComponent<Player>().enabled = true;

        }
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = seconds.ToString();        
    }

    
}
