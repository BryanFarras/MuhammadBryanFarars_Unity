using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    [SerializeField] Animator animator;
    void Awake()
    {
        //do Something on Awake E.g. make an object appearence false
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.SetTrigger("Trig1");
        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        Player.Instance.transform.position = new(0, -4.5f);
        animator.SetTrigger("Trig2");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    
}