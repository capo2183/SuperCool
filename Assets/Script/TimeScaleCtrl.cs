using UnityEngine;
using System.Collections;

public class TimeScaleCtrl
{
    private static TimeScaleCtrl m_Ctrl = new TimeScaleCtrl();
    public  static TimeScaleCtrl Ctrl{ get{ return m_Ctrl;} }

    private float m_TimeScaleValue = 0;
    public float TimeScaleValue{ get{return m_TimeScaleValue;} }


    public void SetSlowMotion(bool _isSlow)
    {
        float _fTimeScale = (_isSlow)? 0.1f : 1f;

        m_TimeScaleValue = _fTimeScale;
        Time.timeScale = _fTimeScale;
    }

    public void SetTimeScaleByDelta(float _Delta)
    {
        float _fTimeScale = 0.1f + Mathf.Abs( _Delta * 2f);

        _fTimeScale = (_fTimeScale > 1)? 1: _fTimeScale;

        m_TimeScaleValue = _fTimeScale;
        Time.timeScale = _fTimeScale;
    }
	
}
