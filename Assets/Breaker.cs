using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Breaker : MonoBehaviour
{
    [SerializeField] private GameObject _panelVictory;
    [SerializeField] private GameObject _panelDefeat;
    [SerializeField] private Text _textPinNumber1;
    [SerializeField] private Text _textPinNumber2;
    [SerializeField] private Text _textPinNumber3;
    [SerializeField] private Text _timer;
    [SerializeField] private Button _drillButton;
    [SerializeField] private Button _hammerButton;
    [SerializeField] private Button _masterkeyButton;
    [SerializeField] private Button _restartVictoryButton;
    [SerializeField] private Button _restartDefeatButton;

    private float _timeNumber = 10;
    private int _digitPinNumber1 = 4;
    private int _digitPinNumber2 = 5;
    private int _digitPinNumber3 = 6;
    private int _victoryDigit = 5;
    private int _minDigit = 0;
    private int _maxDigit = 9;

    void Start()
    {
        _restartVictoryButton.onClick.AddListener(Restart);
        _restartDefeatButton.onClick.AddListener(Restart);
        _drillButton.onClick.AddListener(() => ButtonMethod(1, -1, 0));
        _hammerButton.onClick.AddListener(() => ButtonMethod(-1, 2, -1));
        _masterkeyButton.onClick.AddListener(() => ButtonMethod(-1, 1, 1));

        StartCoroutine(Timer());
    }
   
    private IEnumerator Timer()
    {
        while (_timeNumber > 0)
        {
            _timer.text = Convert.ToString(_timeNumber);
            _timeNumber--;
            yield return new WaitForSeconds(1);
        }
        
        _timer.text = "Время вышло";
        _panelDefeat.SetActive(true);

        DeactivateButton();
    }

    private void ButtonMethod(int digitNumber1, int digitNumber2, int digitNumber3)
    {
        if ((_digitPinNumber1 + digitNumber1 > _maxDigit || _digitPinNumber1 + digitNumber1 < _minDigit) ||
           (_digitPinNumber2 + digitNumber2 > _maxDigit || _digitPinNumber2 + digitNumber2 < _minDigit) ||
           (_digitPinNumber3 + digitNumber3 > _maxDigit || _digitPinNumber3 + digitNumber3 < _minDigit))
           return; 
     
        _digitPinNumber1 += digitNumber1;
        _digitPinNumber2 += digitNumber2;
        _digitPinNumber3 += digitNumber3;

        _textPinNumber1.text = Convert.ToString(_digitPinNumber1);
        _textPinNumber2.text = Convert.ToString(_digitPinNumber2);
        _textPinNumber3.text = Convert.ToString(_digitPinNumber3);

        if (_digitPinNumber1 == _victoryDigit && _digitPinNumber2 == _victoryDigit && _digitPinNumber3 == _victoryDigit)
        {
            _panelVictory.SetActive(true);
            DeactivateButton();
            StopAllCoroutines();
        }
    }

    private void DeactivateButton()
    {
        _drillButton.interactable = false;
        _masterkeyButton.interactable = false;
        _hammerButton.interactable = false;
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}