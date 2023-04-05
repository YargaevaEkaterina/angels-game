using System.Collections;
using UnityEngine;
using UnityEngine.UI;
 
public class CoroutineTimer: MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
 
    public float _timeLeft = 0f;
    public GameManager Gam;
 
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }
 
    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0){
           _timeLeft = 0;
            Gam.EndGame(); 
        }

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}