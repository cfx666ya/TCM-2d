using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogQianyiPi : MonoBehaviour
{
    public AudioSource click;

    public GameObject dialogRight;
    public GameObject dialogWrong;
    
    public GameObject dialog_1;
    public GameObject dialog_2;
    public GameObject dialog_3;
    public GameObject dialog_4;
    public GameObject dialog_5;
    public GameObject dialog_6;
    public GameObject Task;
    public GameObject dialog_7;
    public GameObject dialog_8;

    [Header("场景切换")]
    public string sceneFrom;
    public string sceneTogo;

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

    public void nextDialog_1()
    {
        click.Play();
        dialog_1.SetActive(false);
        dialog_2.SetActive(true);
    }
    public void nextDialog_2()
    {
        click.Play();
        dialog_2.SetActive(false);
        dialog_3.SetActive(true);
    }
    public void nextDialog_3()
    {
        click.Play();
        dialog_3.SetActive(false);
        dialog_4.SetActive(true);
    }
    public void nextDialog_4()
    {
        click.Play();
        dialog_4.SetActive(false);
        dialog_5.SetActive(true);
    }
    public void nextDialog_5()
    {
        click.Play();
        dialog_5.SetActive(false);
        dialog_6.SetActive(true);
    }
    public void nextDialog_6()
    {
        click.Play();
        dialog_6.SetActive(false);
        Task.SetActive(true);
        Time.timeScale = 1f;
    }
    public void afterRight()
    {
        click.Play();
        Task.SetActive(false);
        dialogRight.SetActive(false);
        dialog_7.SetActive(true);
        Time.timeScale = 0f;
    }
    public void afterWrong()
    {
        click.Play();
        dialogWrong.SetActive(false);
        Time.timeScale = 1f;
    }
    public void nextDialog_7()
    {
        click.Play();
        dialog_7.SetActive(false);
        dialog_8.SetActive(true);
    }
    public void nextScene()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
}
