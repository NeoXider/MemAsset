using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeNeoxider : MonoBehaviour
{
    public GameObject _eye1;
    public GameObject _eye2;
    public float _timeEye1;
    public float _timeEye2;
    public float _help;
    public float _stop;
    public GameObject _smile;

    public GameObject _slimeCanvas;
    public GameObject _canvas;
    public float _timer = 0;

    void Start()
    {
        _canvas.SetActive(false);
        _slimeCanvas.SetActive(true);
        Invoke("Eye1", _timeEye1);
        Invoke("Eye2", _timeEye2);
        Invoke("Help", _help);
        Invoke("Stop", _stop);
    }
    private void Eye1()
    {
        _eye1.GetComponent<Animator>().SetTrigger("Eye");
    }
    private void Eye2()
    {
        _eye2.GetComponent<Animator>().SetTrigger("Eye");
    }
    private void Help()
    {
        _smile.GetComponent<Animator>().SetTrigger("Help");
    }
    private void Stop()
    {
        _smile.GetComponent<Animator>().SetTrigger("Stop");
        _canvas.SetActive(true);
        _slimeCanvas.SetActive(false);
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }
}
