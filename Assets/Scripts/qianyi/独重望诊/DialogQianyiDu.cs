using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogQianyiDu : MonoBehaviour
{
    public AudioSource click;
    public GameObject dialogQueren;
    public GameObject dialogWrong;
    public GameObject Chengjiu;
    public GameObject Task;

    [Header("角色")]
    public GameObject playerXin;
    public GameObject playerGan;
    public GameObject playerPi;
    public GameObject playerFei;
    public GameObject playerShen;

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

    public void Right_Xin()
    {
        click.Play();
        playerXin.SetActive(false);
        playerGan.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Gan()
    {
        click.Play();
        playerGan.SetActive(false);
        playerPi.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Pi()
    {
        click.Play();
        playerPi.SetActive(false);
        playerFei.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Fei()
    {
        click.Play();
        playerFei.SetActive(false);
        playerShen.SetActive(true);
        Time.timeScale = 1f;
        dialogQueren.SetActive(false);
    }
    public void Right_Shen()
    {
        click.Play();
        playerShen.SetActive(false);
        Task.SetActive(false);
        Chengjiu.SetActive(true);
        dialogQueren.SetActive(false);
    }
    public void Wrong()
    {
        click.Play();
        dialogQueren.SetActive(false);
        dialogWrong.SetActive(true);
    }
    public void afterWrong()
    {
        click.Play();
        dialogWrong.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoOn()
    {
        click.Play();
        dialogQueren.SetActive(false);
        Time.timeScale = 1f;
    }
    public void backToStart()
    {
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
}
