using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog_sunsimiao_yide : MonoBehaviour
{
    public AudioSource click;
    public GameObject Dialog_1;
    public GameObject Dialog_2;
    public GameObject Dialog_3;
    public GameObject Dialog_4;
    public GameObject Dialog_5;
    public GameObject Dialog_6;
    public GameObject Task;
    public GameObject Chengyu;
    public GameObject Question_1;
    public GameObject Question_2;
    public GameObject Question_3;
    public GameObject Question_4;
    public GameObject Question_5;
    public GameObject Chengjiu;

    public GameObject word_1;
    public GameObject word_2;
    public GameObject word_3;
    public GameObject word_4;
    public GameObject word_5;

    private int countRight;

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

    private void Start()
    {
        countRight = 0;
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
    public void nextDialog_4()
    {
        click.Play();
        Dialog_4.SetActive(false);
        Dialog_5.SetActive(true);
    }
    public void nextDialog_5()
    {
        click.Play();
        Dialog_5.SetActive(false);
        Dialog_6.SetActive(true);
    }
    public void nextDialog_6()
    {
        click.Play();
        Dialog_6.SetActive(false);
        Task.SetActive(true);
        Chengyu.SetActive(true);
    }
    public void showQuestion_1()
    {
        click.Play();
        Question_1.SetActive(true);
    }
    public void showQuestion_2()
    {
        click.Play();
        Question_2.SetActive(true);
    }
    public void showQuestion_3()
    {
        click.Play();
        Question_3.SetActive(true);
    }
    public void showQuestion_4()
    {
        click.Play();
        Question_4.SetActive(true);
    }
    public void showQuestion_5()
    {
        click.Play();
        Question_5.SetActive(true);
    }
    public void right_1()
    {
        click.Play();
        Question_1.SetActive(false);
        word_1.SetActive(true);
        if (countRight == 4)
        {
            Task.SetActive(false);
            Chengyu.SetActive(false);
            Chengjiu.SetActive(true);
        }
        else
        {
            countRight++;
        }
    }
    public void right_2()
    {
        click.Play();
        Question_2.SetActive(false);
        word_2.SetActive(true);
        if (countRight == 4)
        {
            Task.SetActive(false);
            Chengyu.SetActive(false);
            Chengjiu.SetActive(true);
        }
        else
        {
            countRight++;
        }
    }
    public void right_3()
    {
        click.Play();
        Question_3.SetActive(false);
        word_3.SetActive(true);
        if (countRight == 4)
        {
            Task.SetActive(false);
            Chengyu.SetActive(false);
            Chengjiu.SetActive(true);
        }
        else
        {
            countRight++;
        }
    }
    public void right_4()
    {
        click.Play();
        Question_4.SetActive(false);
        word_4.SetActive(true);
        if (countRight == 4)
        {
            Task.SetActive(false);
            Chengyu.SetActive(false);
            Chengjiu.SetActive(true);
        }
        else
        {
            countRight++;
        }
    }
    public void right_5()
    {
        click.Play();
        Question_5.SetActive(false);
        word_5.SetActive(true);
        if (countRight == 4)
        {
            Task.SetActive(false);
            Chengyu.SetActive(false);
            Chengjiu.SetActive(true);
        }
        else
        {
            countRight++;
        }
    }
    public void backToStart()
    {
        click.Play();
        StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
    }
}
