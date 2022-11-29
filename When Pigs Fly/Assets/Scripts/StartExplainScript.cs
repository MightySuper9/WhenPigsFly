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
            text.text = "Once upon a time, there was an Earth which was ruled by pigs. You are Igpay, a mutant pig, as a result of a failed government lab experiment, and you have escaped your prison. You were part of an experiment called G00d Bac0n.";
        }
        else if(stage == 2)
        {
            text.text = "G00d Bac0n was an experiment which fused pig DNA with other animals. The result of the fusal of bird DNA and pig DNA, you had wings, and had no legs, nor a tail.";
        }
        else if(stage == 3)
        {
            text.text = "Before your daring escape, you arranged to meet up somewhere with your fellow labmates, who stole a ship. Although there is a problem with reaching the meeting point. It happens to be in space.";
        }
        else if (stage == 4)
        {
            SceneManager.LoadScene("TheLevel");
        }
    }
}
