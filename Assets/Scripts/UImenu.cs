using UnityEngine.UI;
using UnityEngine;

public class UImenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseText;
    [SerializeField] private GameObject endGameText;
    [SerializeField] private GameObject endScorePanel;
    [SerializeField] private Text savedNPC;
    [SerializeField] private Text money;
    [SerializeField] private Text distance;
    [SerializeField] private Button resume;

    private void Start()
    {
        pauseText.SetActive(false);
        endGameText.SetActive(false);
        endScorePanel.SetActive(false);
        resume.interactable = true;

    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame(int index) 
    {
        StartGameButton.LoadScene(index);    
    }

    private void CheckEndGame() 
    {
        if (Player.alive == false)
        {
            pauseText.SetActive(false);
            endGameText.SetActive(true);
            endScorePanel.SetActive(true);
            RunningScores();
            resume.interactable = false;
        }
        else 
        {
            pauseText.SetActive(true);
        }
    
    }
    /// <summary>
    /// бегущий текст  в финальных очках
    /// </summary>
    private void RunningScores() 
    {
        for (int i = 0; i <= GameScores.amountSavedNPC; i++)
        {
            savedNPC.text = i.ToString();
        }
        for (int j = 0; j <= GameScores.amountCoins; j++)
        {
            money.text = j.ToString();
        }
        for (int k = 0; k <= GameScores.maxDistance; k++)
        {
            distance.text = k.ToString();
        }
    
    
    } 





}
