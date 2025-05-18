using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class IncreaseScore_Button : MonoBehaviour
{
    private Text score_Text;
    private PlayfabManager playFabManager;
    private int score;
    private void Awake()
    {
        foreach (Transform t in transform)
        {
            if (t.name == "Score Text") score_Text = t.GetComponent<Text>();;
        }
        playFabManager = GameObject.Find("Main Camera").GetComponent<PlayfabManager>();
        _IncreaseScore_Button();
    }
    public void _IncreaseScore_Button()
    {
        this.score += 1;
        this.score_Text.text = "Score " + this.score;
        playFabManager.SendLeaderboard(score);
    }
    public void _Debug()
    {
        playFabManager.GetLeaderboard();
    }
}
