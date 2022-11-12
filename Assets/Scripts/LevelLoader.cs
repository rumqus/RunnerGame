using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime;   

    public void LoadScene(int index) 
    {
        FindObjectOfType<AudioManager>().SoundPlay("button");
        StartCoroutine(LoadLevel(index));
        

    }

    IEnumerator LoadLevel(int sceneIndex) 
    {
        Time.timeScale = 1f;
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
        GameScores.NullScore(); // обнуляем текущие результаты
        

    }
  
}
