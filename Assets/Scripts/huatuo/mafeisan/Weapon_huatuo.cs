using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_huatuo : MonoBehaviour
{
    public Transform firePoint;
    public GameObject zhongcaoyaoPrefab;
    public GameObject mafeisanPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Shootzhongcaoyao();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Shootmafeisan();
        }
    }

    void Shootzhongcaoyao()
    {
        // 让世界记住创建的对象，以及位置
        Instantiate(zhongcaoyaoPrefab, firePoint.position, firePoint.rotation);
    }
    void Shootmafeisan()
    {
        // 让世界记住创建的对象，以及位置
        Instantiate(mafeisanPrefab, firePoint.position, firePoint.rotation);
    }
}
