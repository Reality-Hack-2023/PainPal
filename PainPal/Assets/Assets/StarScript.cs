using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public AudioSource _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        _player.Play();
        Invoke("EnableObject", 0.75f);
    }

    void EnableObject()
    {
        gameObject.SetActive(true);
    }
}
