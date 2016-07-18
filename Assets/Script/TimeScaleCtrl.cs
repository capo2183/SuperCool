using UnityEngine;
using System.Collections;

public class TimeScaleCtrl
{
    private float m_TimeScaleValue = 1;
    public float TimeScaleValue{ get{return m_TimeScaleValue;} }


    public void SetSlowMotion(bool _isSlow)
    {
        float _fTimeScale = (_isSlow)? 20f : 1f;

        m_TimeScaleValue = _fTimeScale;        
    }

    public void SetTimeScaleByDelta(float _Delta)
    {
        float _fTimeScale = 0.1f + Mathf.Abs( _Delta * 2f);

        _fTimeScale = (_fTimeScale > 1)? 1: _fTimeScale;

        m_TimeScaleValue = _fTimeScale;
        Time.timeScale = _fTimeScale;
    }
	
}
