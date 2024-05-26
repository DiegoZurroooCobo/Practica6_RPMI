using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicControl : MonoBehaviour
{
    public float time = 110f;
    private float _counter;

    // Start is called before the first frame update
    void Start()
    {
        _counter = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        _counter += Time.deltaTime;

        if ( _counter >= time)
        {
            SceneManager.LoadScene(2);
            _counter = 0f;
        }
    }
}
