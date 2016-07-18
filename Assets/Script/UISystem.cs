using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISystem : MonoBehaviour {

    public Text m_TimeLabel = null;

    public void SetTimeLabelText( string _text )
    {
        m_TimeLabel.text = _text;
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,100),"Summative"))
        {
            ShowSummativePanel(10f);
        }
    }

    public Animator m_SummativeAnimator = null;
    public Text     m_ScoreLabel        = null;
    public void ShowSummativePanel(float _fScore)
    {
        m_SummativeAnimator.SetTrigger("TriggerSwitch");
        SetSummativeValue(_fScore);

    }

    private void SetSummativeValue(float _fScore)
    {
        m_ScoreLabel.text = "Time To Live  : " + _fScore.ToString();   
    }
	
}
