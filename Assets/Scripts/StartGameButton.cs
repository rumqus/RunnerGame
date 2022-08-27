using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void LoadScene(int indexScene) 
    {
        SceneManager.LoadScene(indexScene);
    
    }
}
