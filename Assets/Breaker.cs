using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Breaker : MonoBehaviour
{
    public GameObject PanelVictory;
    public GameObject PanelDefeat;
    public Text A;
    public Text B; 
    public Text C;
    public Text Timer;
    public Button DrillButton;
    public Button HammerButton;
    public Button MasterkeyButton;
    private float _time = 0;
    private float _timeNumber = 60;
    private int _a = 4;
    private int _b = 5;
    private int _c = 6;


    // 3 хода. Изначальное 5 5 5 Hammer(+1,-2,+1), Drill(-1,+1), Drill(-1,+1) 4 5 6
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        _time = _time + Time.deltaTime;
        A.text = Convert.ToString(_a);
        B.text = Convert.ToString(_b);
        C.text = Convert.ToString(_c);

        if (PanelVictory.active == false && PanelDefeat.active == false)
        {
            if (_timeNumber - Mathf.Round(_time) >= 1)
            {
                Timer.text = Convert.ToString(_timeNumber - Mathf.Round(_time));

            }
            else
            {
                Timer.text = "Время вышло";
                PanelDefeat.SetActive(true);
            }

        }
        else
        {
            DrillButton.interactable = false;
            MasterkeyButton.interactable = false;
            HammerButton.interactable = false;
        }

    }

    public void Drill()
    {
        if (_a + 1 > 9 || _b - 1 < 0) return;
        
        _a = _a + 1;
        _b = _b - 1;

        if (_a == 5 && _b == 5 && _c == 5)
        {
            PanelVictory.SetActive(true);
        }
    }

    public void Hammer()
    {
        if (_a - 1 < 0 || _b + 2 > 9 || _c - 1 < 0) return;
        _a = _a - 1;
        _b = _b + 2;
        _c = _c - 1;

        if (_a == 5 && _b == 5 && _c == 5)
        {
            PanelVictory.SetActive(true);

        }
    }

    public void MasterKey()
    {
        if (_a - 1 < 0 || _b + 1 > 9 || _c + 1 > 9) return;
        _a = _a - 1;
        _b = _b + 1;
        _c = _c + 1;
        
        if (_a == 5 && _b == 5 && _c == 5)
        {
            PanelVictory.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
