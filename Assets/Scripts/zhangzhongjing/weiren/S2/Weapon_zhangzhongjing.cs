using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_zhangzhongjing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject zhongcaoyaoPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shootzhongcaoyao();
        }
    }

    void Shootzhongcaoyao()
    {
        // 让世界记住创建的对象，以及位置
        Instantiate(zhongcaoyaoPrefab, firePoint.position, firePoint.rotation);
    }
}
