using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimerControl : MonoBehaviour {

    private static TimerControl m_Ctrl = null;
    public  static TimerControl Ctrl { get{ return m_Ctrl; } }


    private bool m_isEnabled = false;
    private float m_Time = 0f;
    float m_fSpacingTime = 0;

    public Text m_TimeLabel = null;

    private void Awake()
    {
        m_Ctrl = this;   
    }

    public void SetEnabled(bool _isEnabled)
    {
        m_isEnabled = _isEnabled;
    }

	// Update is called once per frame
	void Update () 
    {	
        if (!m_isEnabled) return;
        m_fSpacingTime = Time.deltaTime;

        m_Time += Time.deltaTime;
        m_TimeLabel.text = m_Time.ToString("00.00");
	}
}
