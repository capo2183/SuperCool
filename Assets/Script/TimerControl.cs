using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimerControl : GameSystem {

//    private static TimerControl m_Ctrl = null;
//    public  static TimerControl Ctrl { get{ return m_Ctrl; } }

    private float m_Time = 0f;
    float m_fSpacingTime = 0;

//    public Text m_TimeLabel = null;

//    private void Awake()
//    {
//        m_Ctrl = this;   
//    }

    public override void Awake ()
    {
        
    }

    public override void Start ()
    {
        
    }

    public override void Update ()
    {
        if (!m_isEnabled) return;
        m_fSpacingTime = Time.deltaTime;

        m_Time += Time.deltaTime;        
        MainGameHost.MonoRef.UISystemSetTimeLabel( m_Time.ToString("00.00") );
//        m_TimeLabel.text = m_Time.ToString("00.00");
    }        
}
