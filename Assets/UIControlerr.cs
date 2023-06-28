using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIControlerr : MonoBehaviour
{
    public TextMeshProUGUI[] Text1;
    public TextMeshProUGUI[] Text2;
    int load = -1;
    public GameObject[] btns;
    // void Start()
    // {

    //     // for (int i = 0; i < Text1.Length; i++)
    //     // {
    //     //     Text1[i].enabled = false;
    //     //     Text2[i].enabled = false;
    //     // }
    // }
    public void Set(int x)
    {
        if (x == -1)
        {
            Text1[4].enabled = false;
            Text2[4].enabled = false;
            Text1[5].enabled = false;
            Text2[5].enabled = false;
            gameObject.SetActive(false);
            return;
        }
        for (int i = 0; i < Text1.Length - 2; i++)
        {
            Text1[i].enabled = true;
            Text2[i].enabled = false;
        }
        Text1[x].enabled = false;
        Text2[x].enabled = true;
        load = x;
        Invoke("Set2", 0.5f);
    }

    public void Set2()
    {
        for (int i = 0; i < Text1.Length - 2; i++)
        {
            btns[i].SetActive(true);
            Text1[i].enabled = true;
            Text2[i].enabled = false;
        }
        btns[btns.Length - 2].SetActive(false);
        btns[btns.Length - 1].SetActive(false);
        if (load != -1)
        {
            int t = load;
            load = -1;
            switch (t)
            {
                case 0:
                    {
                        gameObject.SetActive(false);
                        break;
                    }
                case 2:
                    {
                        PlayerPrefs.SetInt("LoadMap", 0);
                        SceneManager.LoadScene(3);
                        break;
                    }
                case 1:
                    {
                        // am thanh
                        break;
                    }
                case 3:
                    {
                        Application.Quit();
                        break;
                    }
            }
        }
    }
    public void GioiThieu(int x)
    {
        // for (int i = 0; i < Text1.Length; i++)
        // {
        //     Text1[i].enabled = false;
        //     Text2[i].enabled = false;
        // }
        for (int i = 0; i < btns.Length; i++)
            btns[i].SetActive(false);
        btns[x].SetActive(true);
        Text1[x].enabled = true;
        Text2[x].enabled = true;
    }
}