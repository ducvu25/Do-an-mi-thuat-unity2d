using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingUI : MonoBehaviour
{
    public Slider _slider;
    public GameObject[] loads;
    float time = 0.5f;
    float time2 = 0.2f;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        _slider.value = 0;
        _slider.maxValue = 100;
        loads[1].SetActive(false);
        loads[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        time2 -= Time.deltaTime;
        if (time <= 0)
        {
            if (n == 2)
            {
                n = 0;
                loads[1].SetActive(false);
                loads[2].SetActive(false);
            }
            else
            {
                n++;
                loads[n].SetActive(true);
            }
            time = 0.5f;
        }
        if (time2 <= 0)
        {
            int x = (int)Random.Range(1, 10);
            _slider.value += x;
            if (_slider.value >= _slider.maxValue)
                SceneManager.LoadScene(PlayerPrefs.GetInt("LoadMap"));
            time2 = 0.2f;
        }
    }
}
