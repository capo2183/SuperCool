using UnityEngine;
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
        m_InputCtrl.Update();
        m_TimeCtrl.Update();
        m_BulletManager.Update();
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
    public void BulletManagerSetLinerDrag()
    {
        float _fLinerDrag = m_TimeScaleCtrl.TimeScaleValue;
        m_BulletManager.SetLinerDrag( _fLinerDrag );
    }
    #endregion

    #region UI System
    public void UISystemSetTimeLabel(string _sText)
    {
        m_UISystem.SetTimeLabelText(_sText);
    }
    #endregion
   
}


