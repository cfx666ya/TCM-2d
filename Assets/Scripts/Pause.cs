using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject BackBtn;
    public AudioSource click;
    private string sceneTogo = "Start";

    // 协程方法
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // 以激活的方式加载场景
        // 设置新场景为激活场景
        // 此时场景中一共有两个场景，序号为0与1，通过数量-1从而找到新加载的场景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return SceneManager.UnloadSceneAsync(from); // 卸载场景      
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }

    public void ShowPauseMenu()
    {
        click.Play();
        BackBtn.SetActive(true);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;//让时间运算比率为0从而达到暂停的效果
    }

    public void BackGame()
    {
        click.Play();
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        BackBtn.SetActive(false);
    }

    public void BackToMain()
    {
        click.Play();
        Time.timeScale = 1f;
        Scene sceneFrom = SceneManager.GetActiveScene();
        Debug.Log(sceneFrom.name);
        StartCoroutine(TransitionToScene(sceneFrom.name, sceneTogo));
        
    }
}
