using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogBianqueQiguo_4 : MonoBehaviour
{
    public AudioSource click;
    public GameObject Dialog_qiguo_select;
    public GameObject Dialog_qihuanhou;
    public GameObject Dialog_1;
    public GameObject Dialog_2;
    public GameObject Dialog_3;

    [Header("场景切换")]
    public string sceneFrom;
    public string sceneTogo;

    public void wangshu()
    {
        click.Play();
        Dialog_qiguo_select.SetActive(false);
        Dialog_1.SetActive(true);
    }
    public void jieshu()
    {
        click.Play();
        Dialog_qiguo_select.SetActive(false);
        Dialog_qihuanhou.SetActive(true);
    }
    public void qihuanhouNext()
    {
        click.Play();
        Dialog_qihuanhou.SetActive(false);
        Dialog_qiguo_select.SetActive(true);
    }
    public void nextDialog_1()
    {
        click.Play();
        Dialog_1.SetActive(false);
        Dialog_2.SetActive(true);
    }
    public void nextDialog_2()
    {
        click.Play();
        Dialog_2.SetActive(false);
        Dialog_3.SetActive(true);
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
