using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    int index_map = 0;
    public GameObject[] maps;
    public GameObject CloseMap;
    public GameObject DataGame;
    public float speed = 200f;
    // Update is called once per frame
    public void Next()
    {
        if (index_map < 3)
        {
            index_map++;
            for (int j = 0; j < 12; j++)
                for (int i = 0; i < maps.Length; i++)
                {
                    if (i == index_map)
                    {
                        maps[i].gameObject.transform.position = maps[i].gameObject.transform.position - new Vector3(1, 0, 0.5f);
                    }
                    else
                    if (i == index_map - 1)
                    {
                        maps[i].gameObject.transform.position = maps[i].gameObject.transform.position + new Vector3(-1, 0, 0.5f);
                    }
                    else
                    {
                        maps[i].gameObject.transform.position = maps[i].gameObject.transform.position - new Vector3(1, 0, 0);
                    }

                }
            // Data data = DataGame.GetComponent<Data>();
            // if (!data.maps[index_map])
            //     CloseMap.SetActive(true);
            // else
            //     CloseMap.SetActive(false);
        }
    }
    public void Previous()
    {
        if (index_map > 0)
        {
            index_map--;
            for (int j = 0; j < 12; j++)
                for (int i = 0; i < maps.Length; i++)
                {
                    if (i == index_map)
                    {
                        maps[i].gameObject.transform.position = maps[i].gameObject.transform.position + new Vector3(1, 0, -0.5f);
                    }
                    else if (i == index_map + 1)
                    {
                        maps[i].gameObject.transform.position = maps[i].gameObject.transform.position + new Vector3(1, 0, 0.5f);
                    }
                    else
                    {
                        maps[i].gameObject.transform.position = maps[i].gameObject.transform.position + new Vector3(1, 0, 0);
                    }

                }
            // Data data = DataGame.GetComponent<Data>();
            // if (!data.maps[index_map])
            //     CloseMap.SetActive(true);
            // else
            //     CloseMap.SetActive(false);
        }
    }
    public void LoadMap()
    {
        if (index_map < 2)
        {
            // Data data = DataGame.GetComponent<Data>();
            // if (data.maps[index_map])
            PlayerPrefs.SetInt("LoadMap", index_map + 1);
            SceneManager.LoadScene(3);
        }
    }
    public void LoadMap(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
