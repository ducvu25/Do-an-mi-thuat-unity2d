using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerController : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject Finish;
    public GameObject DataGame;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            Animator ani = stars[i].GetComponent<Animator>();
            ani.SetBool("Menu", true);
        }
        Finish.SetActive(false);
        Invoke("GioiThieu1", 0.5f);
    }
    public void SetStar()
    {
        Animator ani = stars[n].GetComponent<Animator>();
        ani.SetBool("Menu", false);
        n++;
        if (n == 3)
            Win();
    }
    void Win()
    {
        Data data = DataGame.GetComponent<Data>();
        for (int i = 0; i < data.maps.Length; i++)
            if (!data.maps[i])
            {
                data.maps[i] = true;
                PlayerPrefs.SetInt("LoadMap", 0);
                SceneManager.LoadScene(3);
            }
    }
    void GioiThieu1()
    {
        Finish.SetActive(true);
        UIControlerr ui = Finish.GetComponent<UIControlerr>();
        ui.GioiThieu(4);
    }
    public void Pause()
    {
        Finish.SetActive(true);
        UIControlerr ui = Finish.GetComponent<UIControlerr>();
        ui.Set2();
    }
}
