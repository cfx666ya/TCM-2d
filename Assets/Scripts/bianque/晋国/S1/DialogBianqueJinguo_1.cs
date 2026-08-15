using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogBianqueJinguo_1 : MonoBehaviour
{
    public AudioSource click;
    public GameObject Dialog_jinguo_select;
    public GameObject Dialog_bamai;
    public GameObject Dialog_jieshu;
    public GameObject Dialog_1;
    public GameObject Dialog_2;
    public GameObject Task;

    [Header("场景切换")]
    public string sceneFrom;
    public string sceneTogo;

    public void bamai()
    {
        click.Play();
        Task.SetActive(false);
        Dialog_jinguo_select.SetActive(false);
        Dialog_bamai.SetActive(true);
    }
    public void bamaiNext()
    {
        click.Play();
        Dialog_bamai.SetActive(false);
        Dialog_jinguo_select.SetActive(true);
    }
    public void jieshu()
    {
        click.Play();
        Dialog_jinguo_select.SetActive(false);
        Dialog_jieshu.SetActive(true);
    }
    public void jieshuNext()
    {
        click.Play();
        Dialog_jieshu.SetActive(false);
        Dialog_1.SetActive(true);
    }
    public void nextDialog_1()
    {
        click.Play();
        Dialog_1.SetActive(false);
        Dialog_2.SetActive(true);
    }
    public void nextScene()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }

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
}
