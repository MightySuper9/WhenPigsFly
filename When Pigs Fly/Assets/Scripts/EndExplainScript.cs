using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndExplainScript : MonoBehaviour
{
    public int stage = 1;
    public TextMeshProUGUI text;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stage += 1;
        }
        if (stage == 1)
        {
            text.text = "You have gotten into the escape ship. You are surrounded by healthy pigs. 'Hello.' You say. Click to continue.";
        }
        else if (stage == 2)
        {
            text.text = "The Pig Leader looks at you. It turns pale. 'Oh no' it says. Click to continue.";
        }
        else if (stage == 3)
        {
            text.text = "'Wait, it's ok.' You say, and then there is a collective grunt as the legs fall off the pigs around you.";
        }
        else if (stage == 4)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
