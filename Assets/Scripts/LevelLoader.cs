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
        
        StartCoroutine(LoadLevel(index));
        Debug.Log("ping");
    }


    private void Start()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    animator.enabled = false;
        //}
    }


    IEnumerator LoadLevel(int sceneIndex) 
    {
        Time.timeScale = 1f;
        //animator.enabled = true;
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("пытаюсь загрузить сценцу");
        SceneManager.LoadScene(sceneIndex);

    
    }
}
