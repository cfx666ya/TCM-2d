using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog_sunsimiao_furu : MonoBehaviour
{
    public AudioSource click;
    public GameObject Dialog_1;
    public GameObject Dialog_2;
    public GameObject Dialog_3;
    public GameObject Dialog_4;
    public GameObject Chengjiu;

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
        Dialog_1.SetActive(false);
        Dialog_2.SetActive(true);
    }
    public void nextDialog_2()
    {
        click.Play();
        Dialog_2.SetActive(false);
        Dialog_3.SetActive(true);
    }
    public void nextDialog_3()
    {
        click.Play();
        Dialog_3.SetActive(false);
        Dialog_4.SetActive(true);
    }
    public void showChengjiu()
    {
        click.Play();
        Dialog_4.SetActive(false);
        Chengjiu.SetActive(true);
    }
    public void backToStart()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
}
