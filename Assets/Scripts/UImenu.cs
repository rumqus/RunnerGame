using UnityEngine.UI;
using UnityEngine;

public class UImenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

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





}
