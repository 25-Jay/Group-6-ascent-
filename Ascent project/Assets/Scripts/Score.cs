using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoretext;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + score;
        
    }

    void OntriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Outofbounds")
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (other.gameObject.tag == "enermy")
        {
            SceneManager.LoadScene("LoseScene");
        }

        
    }
}
