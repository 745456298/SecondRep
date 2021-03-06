﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    public  GameObject[] carModels = new GameObject[4];
    List<GameObject> preGai = new List<GameObject>();
    List<GameObject> carGulu = new List<GameObject>();
    ChangeType type = ChangeType.None;
    public GameObject gamePrefa;
    GameObject waiguanRoot,mainBtnsRoot,ErJiJieMianRoot;
    GameObject[] mainBtns = new GameObject[4];
    GameObject[] erjiBtns = new GameObject[4];
	// Use this for initialization
    void Awake() {
        seData = new SelectData();
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/LeftButton")).onClick = OnClickChange;//左右按钮
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/RightButton")).onClick = OnClickChange;//左右按钮
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/qiangaiBtn")).onClick = OnPreGaiHandle;//切换选择前盖按钮
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/Container/qiangaiBtn1")).onClick = OnCLickSelectQianGai;
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/Container/qiangaiBtn2")).onClick = OnCLickSelectQianGai;
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/Container/qiangaiBtn3")).onClick = OnCLickSelectQianGai;
        UIEventListener.Get(Utils.Find(this.gameObject, "WaiGuan/Container/qiangaiBtn4")).onClick = OnCLickSelectQianGai;
        waiguanRoot = Utils.Find(this.gameObject, "WaiGuan");
        ErJiJieMianRoot = Utils.Find(this.gameObject, "ErJiJieMian");
        mainBtnsRoot = Utils.Find(this.gameObject, "MainBtns");
        for (int i = 0; i < 4; i++)
        {
            mainBtns[i] = Utils.Find(mainBtnsRoot,"car"+(i+1));
            UIEventListener.Get(mainBtns[i]).onClick = OnSelecetCarMainRoot;
            erjiBtns[i] = Utils.Find(ErJiJieMianRoot, "car" + (i + 1));
            //UIEventListener.Get(erjiBtns[i]).onClick = OnErJieSeclectHandle;
        }
        UIEventListener.Get(erjiBtns[0]).onClick = OnCarWaiHandle;
        UIEventListener.Get(erjiBtns[1]).onClick = OnCanShuHandle;
        UIEventListener.Get(erjiBtns[2]).onClick = OnNeiShiHandle;
        UIEventListener.Get(erjiBtns[3]).onClick = OnGaiZhuangHandle;
        //UIEventListener.Get(Utils.Find(this.gameObject, "LeftWheelBtn")).onClick = OnLeftWheelHandl;
    }
    //二级界面改装按钮
    private void OnGaiZhuangHandle(GameObject go)
    {
        ErJiJieMianRoot.SetActive(false);
        waiguanRoot.SetActive(true);
        SetErJiE(false);
        ResetHideOrShow(true);
        UpdateShowModle(seData.selcetCarIndex, type);
        Debug.Log("current car index is" + seData.selcetCarIndex);
        
    }
    //二级界面参数按钮
    private void OnCanShuHandle(GameObject go)
    {
        
    }
    //二级界面内饰按钮
    private void OnNeiShiHandle(GameObject go)
    {
        
    }
    //二级界面车型外观
    private void OnCarWaiHandle(GameObject go)
    {
       
    }

    //private int carIndex;
    //private void OnErJieSeclectHandle(GameObject go)
    //{
    //    UpdateShowModle(0, ChangeType.None);//out show ,can  change color
    //}
    SelectData seData;
    private void OnSelecetCarMainRoot(GameObject go)
    {
        seData.selcetCarIndex = int.Parse(go.name.Substring(3));
        Debug.Log("current car index is" + seData.selcetCarIndex);
        SetMainBool(false);
        SetErJiE(true);
    }   
	void Start () {
        type = ChangeType.None;
        UpdateShowModle(0, type);
        
        SetWaiGuan(false);
        SetErJiE(false);
        SetMainBool(true);
        ResetHideOrShow(false);
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
    void ResetHideOrShow(bool isSHow) {
        gamePrefa.SetActive(isSHow);            
    }
    void SetWaiGuan(bool isShow) {
        waiguanRoot.SetActive(isShow);
    }
    void SetMainBool(bool isShow) {
        mainBtnsRoot.SetActive(isShow);
    }
    void SetErJiE(bool isShow) {
        ErJiJieMianRoot.SetActive(isShow);
    }
    private void OnCLickSelectQianGai(GameObject go) {
        if (go.name == "qiangaiBtn1")
        {
            UpdateShowXiaModle(ChangeType.qiangai,0);
        }
        else if (go.name == "qiangaiBtn2")
        {
            UpdateShowXiaModle(ChangeType.qiangai, 1);
        }
        else if (go.name == "qiangaiBtn3")
        {
            UpdateShowXiaModle(ChangeType.qiangai, 2);
        }
        else if (go.name == "qiangaiBtn4")
        {
            UpdateShowXiaModle(ChangeType.qiangai, 3);
        }
    }
    //int index = 0;         
    private void OnClickChange(GameObject go)
    {
        if (go.name == "LeftButton") {
            Debug.Log("1111");
            if (seData.selcetCarIndex > 0)
            {
                seData.selcetCarIndex--;
                
            }
        }
        else if (go.name == "RightButton") {
            Debug.Log("222");
            if (seData.selcetCarIndex < 3)
            {
                seData.selcetCarIndex++;                
            }
        }
        for (int i = 0; i < 4; i++)
        {
            //carModels[i]
        }
        UpdateShowModle(seData.selcetCarIndex, type);
    }
    private void OnPreGaiHandle(GameObject go)
    {
        UpdateShowXiaModle(ChangeType.qiangai);
    }
    private void OnLeftWheelHandl(GameObject go)
    {
        //UpdateShowXiaModle(index, ChangeType.guolu);       
    }
    public void UpdateShowModle(int index,ChangeType type) {
        for (int i = 0; i < 4; i++)
        {
            if (i == index)
            {
                carModels[i].SetActive(true);
            }
            else {
                carModels[i].SetActive(false);
            }
        }                
        //for (int i = 0; i < 4; i++)
        //{
        //foreach (Transform t in carModels[index].transform.FindChild("QianGaiPos").GetComponentsInChildren<Transform>())
        //{
        //  preGai.Add(t.gameObject);
        //}
        //preGai.Clear();
        //foreach (Transform child in carModels[index].transform.FindChild("QianGaiPos"))
        //{
        //     preGai.Add(child.gameObject);
        //}
        //}
        UpdateShowXiaModle(type);
        //preGai.Add();
    }
    
    public void UpdateShowXiaModle(ChangeType type,int qianGaiIndex=0) {
        
        switch ((int)type)
        {
            case 1:
                preGai.Clear();
                foreach (Transform child in carModels[seData.selcetCarIndex].transform.FindChild("QianGaiPos"))
                {
                    preGai.Add(child.gameObject);
                }
                foreach (var item in preGai)
                {
                    item.SetActive(false);
                }
                preGai[qianGaiIndex].SetActive(true);
                break;
            case 2:

                break;
            default:
                break;
        }
    }
}
