using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectgame : MonoBehaviour
{
    //public Transform this;

    public Text _text;
    public int score=0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other){
            if(other.gameObject.tag=="star"){
                score++;
                _text.text = score.ToString();
                other.gameObject.SetActive(false);
            }
        }
}
