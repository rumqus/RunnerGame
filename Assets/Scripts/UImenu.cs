using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UImenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseText;
    [SerializeField] private GameObject endScorePanel;
    [SerializeField] private TextMeshProUGUI savedNPC;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private Button resume;
    private float speedCounting;
    private float tempScore;

    private void Awake()
    {
        pauseText.SetActive(false);
        endScorePanel.SetActive(false);
        resume.interactable = true;
        speedCounting = 0.1f;
    }

    private void OnEnable()
    {
        Actions.endGame += CheckEndGame;
    }
    private void OnDisable()
    {
        Actions.endGame -= CheckEndGame;
    }
        

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseText.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<AudioManager>().SoundPlay("button");
    }

    public void UnPauseGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().SoundPlay("button");
    }

    public void QuitGame(int index) 
    {
        FindObjectOfType<AudioManager>().SoundPlay("button");
        StartGameButton.LoadScene(index);    
    }

    public void CheckEndGame() 
    {
        if (Player.alive == false)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            pauseText.SetActive(false);
            endScorePanel.SetActive(true);
            RunningScores();
            resume.interactable = false;
        }           
    }
    /// <summary>
    /// бегущие очки  в финальных очках
    /// </summary>
    private void RunningScores() 
    {
        StartCoroutine(CountUp(GameScores.amountSavedNPC, savedNPC));
        StartCoroutine(CountUp(GameScores.amountCoins, money));
        StartCoroutine(CountUp(GameScores.maxDistance, distance));
    }

    IEnumerator CountUp(int targetScore, TextMeshProUGUI targetScoreDisplay)
    {
        while (tempScore < targetScore)
        {
            tempScore += speedCounting;
            tempScore = Mathf.Clamp(tempScore, 0f, targetScore);
            targetScoreDisplay.text = tempScore.ToString("0");
            yield return null;
        }
    }

    


}
