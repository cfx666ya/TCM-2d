using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public string startScene; // 开始场景

    public CanvasGroup fadeCanvasGroup; // 获得Panels的变量
    public float fadeDuration; // 控制切换的时间
    private bool isFade; // 判断是否正在切换场景

    private void Start()
    {
        // 通过协程加载初始场景
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }

    // 切换场景
    public void Transition(string from, string to)
    {
        // 如果不是正在场景切换，那么执行协程
        if (!isFade)
        {
            StartCoroutine(TransitionToScene(from, to));
        }
    }

    // 协程方法
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1); // 场景切换完毕前为全黑
                              // 在执行完上面的才会执行以下内容
                              // 如果想要同时执行，可以将上面的代码修改为startCoroutine

        // 如果有第一个场景，才会执行卸载的动作，否则直接加载即可
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from); // 卸载场景
        }

        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // 以激活的方式加载场景

        // 设置新场景为激活场景
        // 此时场景中一共有两个场景，序号为0与1，通过数量-1从而找到新加载的场景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        yield return Fade(0); // 场景执行完毕后为透明
    }

    /// <summary>
    /// 渐入渐出效果
    /// </summary>
    /// <param name="targetAlpha">1是黑，0是透明</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true; // 对应Panels中CanvasGroup的属性

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        // 如果两个值不相似，那么缓慢让值变为目标值
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null; // 反复执行循环
        }

        fadeCanvasGroup.blocksRaycasts = false; // 对应Panels中CanvasGroup的属性
        isFade = false;
    }
}
