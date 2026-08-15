using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Bowuguan : MonoBehaviour
{
    public AudioSource click;
    public GameObject Dialog_bianque;
    public GameObject Question_bianque;

    public GameObject Dialog_qianyi;
    public GameObject Question_qianyi;

    public GameObject Dialog_huatuo;
    public GameObject Question_huatuo;

    public GameObject Dialog_dongfeng;
    public GameObject Question_dongfeng;

    public GameObject Dialog_sunsimiao;
    public GameObject Question_sunsimiao;

    public GameObject Dialog_lishizhen;
    public GameObject Question_lishizhen;

    public GameObject Dialog_zhangzhongjing;
    public GameObject Question_zhangzhongjing;

    public string sceneFrom;
    public string sceneTogoBianque;
    public string sceneTogoQianyi;
    public string sceneTogoHuatuo;
    public string sceneTogoDongfeng;
    public string sceneTogoSunsimiao;
    public string sceneTogoLishizhen;
    public string sceneTogoZhangzhongjing;

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

    public void ShowBianque()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_bianque.SetActive(true);
        Question_bianque.SetActive(false);
    }
    public void BackBianque()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_bianque.SetActive(false);
        Question_bianque.SetActive(false);
    }
    public void LoadBianque()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoBianque));
    }

    public void ShowQianyi()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_qianyi.SetActive(true);
        Question_qianyi.SetActive(false);
    }
    public void BackQianyi()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_qianyi.SetActive(false);
        Question_qianyi.SetActive(false);
    }
    public void LoadQianyi()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoQianyi));
    }

    public void ShowHuatuo()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_huatuo.SetActive(true);
        Question_huatuo.SetActive(false);
    }
    public void BackHuatuo()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_huatuo.SetActive(false);
        Question_huatuo.SetActive(false);
    }
    public void LoadHuatuo()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoHuatuo));
    }

    public void ShowDongfeng()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_dongfeng.SetActive(true);
        Question_dongfeng.SetActive(false);
    }
    public void BackDongfeng()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_dongfeng.SetActive(false);
        Question_dongfeng.SetActive(false);
    }
    public void LoadDongfeng()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoDongfeng));
    }
    public void ShowSunsimiao()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_sunsimiao.SetActive(true);
        Question_sunsimiao.SetActive(false);
    }
    public void BackSunsimiao()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_sunsimiao.SetActive(false);
        Question_sunsimiao.SetActive(false);
    }
    public void LoadSunsimiao()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoSunsimiao));
    }

    public void ShowLishizhen()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_lishizhen.SetActive(true);
        Question_lishizhen.SetActive(false);
    }
    public void BackLishizhen()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_lishizhen.SetActive(false);
        Question_lishizhen.SetActive(false);
    }
    public void LoadLishizhen()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoLishizhen));
    }

    public void ShowZhangzhongjing()
    {
        click.Play();
        Time.timeScale = 0f;
        Dialog_zhangzhongjing.SetActive(true);
        Question_zhangzhongjing.SetActive(false);
    }
    public void BackZhangzhongjing()
    {
        click.Play();
        Time.timeScale = 1f;
        Dialog_zhangzhongjing.SetActive(false);
        Question_zhangzhongjing.SetActive(false);
    }
    public void LoadZhangzhongjing()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogoZhangzhongjing));
    }
    public void Quit()
    {
        click.Play();
        Application.Quit();
    }
}
