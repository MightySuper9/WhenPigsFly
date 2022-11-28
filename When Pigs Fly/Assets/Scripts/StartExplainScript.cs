using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartExplainScript : MonoBehaviour
{
    public int stage = 1;
    public TextMeshProUGUI text;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            stage += 1;
        }
        if (stage == 1)
        {
            text.text = "Once upon a time, there was a reality in which pigs ruled the earth. Click to continue.";
        }
        else if(stage == 2)
        {
            text.text = "They lived in harmony, until a disease struck. It was called the Bird Flew. Click to continue.";
        }
        else if(stage == 3)
        {
            text.text = "It caused a pig's legs to pop off and the pig to grow wings. Click to continue.";
        }
        else if(stage == 4)
        {
            text.text = "The pig government ordered all healthy pigs to board a spaceship to escape and settle somewhere else. Click to continue.";
        }
        else if(stage == 5)
        {
            text.text = "You are a brave pig, who is infected with the Bird Flew. You know that it does not spread, and you must explain to the government. Click to continue.";
        }
        else if(stage == 6)
        {
            text.text = "Good luck. Click to begin.";
        }
        else if (stage == 7)
        {
            SceneManager.LoadScene("TheLevel");
        }
    }
}
