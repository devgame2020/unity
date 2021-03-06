﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject parentObj;

    public GameObject enemyBPrefab;
    public GameObject enemyLPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemySPrefab;
    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;
    public GameObject bulletPlayerAPrefab;
    public GameObject bulletPlayerBPrefab;
    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;

    public GameObject bulletFollowerPrefab;

    GameObject[] enemyB;
    GameObject[] enemyL;
    GameObject[] enemyM;
    GameObject[] enemyS;

    GameObject[] itemCoin;
    GameObject[] itemPower;
    GameObject[] itemBoom;

    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayerB;
    GameObject[] bulletEnemyA;
    GameObject[] bulletEnemyB;
    GameObject[] bulletBossA;
    GameObject[] bulletBossB;

    GameObject[] bulletFollower;

    void Awake() {
        enemyB = new GameObject[10];
        enemyL = new GameObject[10];
        enemyM = new GameObject[10];
        enemyS = new GameObject[20];

        itemCoin = new GameObject[10];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        bulletPlayerA = new GameObject[20];
        bulletPlayerB = new GameObject[10];
        bulletEnemyA = new GameObject[20];
        bulletEnemyB = new GameObject[20];

        bulletBossA = new GameObject[200];
        bulletBossB = new GameObject[200];

        bulletFollower = new GameObject[20];

        Generate();
    }

    GameObject CreateObject(GameObject prefab) {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        obj.transform.parent = parentObj.transform;
        return obj;
    }

    void Generate() {
        for (int i = 0; i < enemyB.Length; i++)
        {
            enemyB[i] = CreateObject(enemyBPrefab);
        }

        for (int i = 0; i < enemyL.Length; i++)
        {
            enemyL[i] = CreateObject(enemyLPrefab);
        }

        for (int i=0;i<enemyM.Length;i++) {
            enemyM[i] = CreateObject(enemyMPrefab);
        }

        for(int i=0;i<enemyS.Length;i++) {
            enemyS[i] = CreateObject(enemySPrefab);
        }

        for(int i=0;i<itemCoin.Length;i++) {
            itemCoin[i] = CreateObject(itemCoinPrefab);
        }

        for(int i=0;i<itemPower.Length;i++) {
            itemPower[i] = CreateObject(itemPowerPrefab);
        }

        for(int i=0;i<itemBoom.Length;i++) {
            itemBoom[i] = CreateObject(itemBoomPrefab);
        }

        for(int i=0;i<bulletPlayerA.Length;i++) {
            bulletPlayerA[i] = CreateObject(bulletPlayerAPrefab);
        }
        for(int i=0;i<bulletPlayerB.Length;i++) {
            bulletPlayerB[i] = CreateObject(bulletPlayerBPrefab);
        }

        for(int i=0;i<bulletEnemyA.Length;i++) {
            bulletEnemyA[i] = CreateObject(bulletEnemyAPrefab);
        }
        for(int i=0;i<bulletEnemyB.Length;i++) {
            bulletEnemyB[i] = CreateObject(bulletEnemyBPrefab);
        }
        for (int i = 0; i < bulletBossA.Length; i++)
        {
            bulletBossA[i] = CreateObject(bulletBossAPrefab);
        }
        for (int i = 0; i < bulletBossB.Length; i++)
        {
            bulletBossB[i] = CreateObject(bulletBossBPrefab);
        }
        for (int i = 0; i < bulletFollower.Length; i++)
        {
            bulletFollower[i] = CreateObject(bulletFollowerPrefab);
        }
    }


    public GameObject MakeObj(string type, Vector3 pos, Quaternion rot) {
        Debug.Log(type);
        GameObject[] targetPool = null;

        switch(type) {
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
        }

        Debug.Log("MakeObj:"+type);

        for (int i=0;i<targetPool.Length;i++) {
            if(!targetPool[i].activeSelf) {
                targetPool[i].SetActive(true);
                targetPool[i].transform.position = pos;
                targetPool[i].transform.rotation = rot;
                return targetPool[i];
            }
        }

        Debug.Log(type + " : Free Object is Not!! ㅠㅠ ");
        return null;

    }

    public List<GameObject> GetActiveEnemyPool() {
        List<GameObject> list = new List<GameObject>();


        for (int i = 0; i < enemyB.Length; i++)
            if (enemyB[i].activeSelf)
                list.Add(enemyB[i]);

        for (int i=0;i<enemyL.Length;i++) 
            if(enemyL[i].activeSelf) 
                list.Add(enemyL[i]);
        for(int i=0;i<enemyM.Length;i++) 
            if(enemyM[i].activeSelf) 
                list.Add(enemyM[i]);
        for(int i=0;i<enemyS.Length;i++) 
            if(enemyS[i].activeSelf) 
                list.Add(enemyS[i]);
        return list;
    }

    public List<GameObject> GetActiveEnemyBulletPool() {
        List<GameObject> list = new List<GameObject>();

        for(int i=0;i<bulletEnemyA.Length;i++) 
            if(bulletEnemyA[i].activeSelf) 
                list.Add(bulletEnemyA[i]);
        for(int i=0;i<bulletEnemyB.Length;i++) 
            if(bulletEnemyB[i].activeSelf) 
                list.Add(bulletEnemyB[i]);
        return list;
    }

    public GameObject[] GetPool(string type) {
        GameObject[] targetPool = null;
        switch(type) {
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
        }
        return targetPool;

    }

}
