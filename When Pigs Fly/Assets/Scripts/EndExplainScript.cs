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
            text.text = "You have gotten into the escape ship. You look at your fellow labmates and the ship flies off into the distance. The End.";
        }
        else if (stage == 2)
        {
            text.text = "Thanks for playing! " +
                "You died " + CheckpointScript.attempts + " times!";
        }
        else if (stage == 3)
        {
            CheckpointScript.attempts = 0;
            SceneManager.LoadScene("TitleScene");
        }
    }
}
