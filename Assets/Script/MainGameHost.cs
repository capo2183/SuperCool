﻿using UnityEngine;
using System.Collections;

public class MainGameHost : MonoBehaviour {

    private static MainGameHost m_MonoRef = null;
    public static MainGameHost MonoRef{ get{ return m_MonoRef; } }


    public  UISystem    m_UISystem = null;
    private InputControl m_InputCtrl  = null;         //input 的 Ctrl
    private TimerControl m_TimeCtrl   = null;
    private TimeScaleCtrl m_TimeScaleCtrl = null;
    public  BulletManager m_BulletManager = null;
    private PlayerControl m_Player  = null;


    #region MonoBehaviour 
    private void Awake()
    {
        Application.targetFrameRate = 60;
        m_MonoRef = this;

    }
    void Start () 
    {
        InitGameSystem();
        m_InputCtrl.Start();
    }

    // Update is called once per frame
    void Update () 
    {
        m_BulletManager.Update();
        m_InputCtrl.Update();
        m_TimeCtrl.Update();
    }
    private void OnDestroy()
    {
        m_MonoRef = null;
    }
    #endregion

    /// <summary>
    /// Init All Game systems.
    /// </summary>
    private void InitGameSystem()
    {
        m_Player = PlayerControl.Ctrl;
        m_InputCtrl = new InputControl();
        m_TimeScaleCtrl = new TimeScaleCtrl();
        m_TimeCtrl = new TimerControl();
         
    }

    #region Input Ctrl
    /// <summary>
    /// Input Ctrl trigger move.
    /// </summary>
    public void InputCtrlOnMove(Vector3 _MoveV3)
    {
        m_Player.Move(_MoveV3);
    }
    #endregion

    #region Time Ctrl
    public void TimeCtrlSetEnabled(bool _isEnabled)
    {
        m_TimeCtrl.SetEnabled(_isEnabled);
    }

    public void TimeCtrlResetTimer()
    {
        m_TimeCtrl.ResetTimer();
    }

    public float GetTime
    {
        get
        {
            return m_TimeCtrl.fTime;
        }
    }
    #endregion

    #region TimeScale Ctrl
    public void TimeScaleCtrlSetSlowMotion(bool _isSlowMotion)
    {
        m_TimeScaleCtrl.SetSlowMotion(_isSlowMotion);
    }
    public void TimeScaleCtrlSetTimeScaleByDelta(float _Delta)
    {
        m_TimeScaleCtrl.SetTimeScaleByDelta(_Delta);
    }
    public float GetTimeScale
    {
        get
        {
            return m_TimeScaleCtrl.TimeScaleValue;
        }
    }
    #endregion

    #region BulletManager
    public void BulletManagerSetEnabled(bool _isEnabled)
    {
        m_BulletManager.SetEnabled(_isEnabled);
    }
    public void BulletManagerSetDeltaTime()
    {
        float _fLinerDrag = m_TimeScaleCtrl.TimeScaleValue;
        m_BulletManager.SetDeltaTime( _fLinerDrag );
    }
    #endregion

    #region UI System
    public void UISystemSetTimeLabel(string _sText)
    {
        m_UISystem.SetTimeLabelText(_sText);
    }
    public void ShowSummativePanel(float _fScore)
    {
        m_UISystem.ShowSummativePanel(_fScore);
    }
    #endregion
   
    public void ResloadLevel()
    {
        Application.LoadLevel(0);   
    }
}


