using UnityEngine;
using System.Collections;

public class InputControl:GameSystem 
{
    public delegate void Move(Vector3 _Vector3);
    public Move OnMove;

    private float m_fHorizontal             = 0;
    private int m_iScreenW = 0;
    private bool m_isInputStart = false;
    private bool m_LastState = false;
    public InputControl()
    {

    }

    public override void Start () {
        m_iScreenW = Screen.width;       
//        m_TimeControl = TimerControl.Ctrl;
	}
	
    public override void Update () 
    {
        m_fHorizontal = Input.GetAxis("Horizontal");

        #if UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            bool _isLeft = (Input.GetTouch(0).position.x > m_iScreenW / 2 ) ? false : true;                       

            if (Input.GetTouch(0).position.y > Screen.height / 10 )
            {
                float _x = (_isLeft)? -0.1f : 0.1f;

                m_fHorizontal += _x;

                if (m_fHorizontal > 1)
                    m_fHorizontal = 1;
                else if(m_fHorizontal < -1)
                    m_fHorizontal = -1;
            }
//            m_fHorizontal = Input.GetTouch(0).deltaPosition.x;
//            m_fHorizontal = m_fHorizontal / 5;
        }
        else
        {
            if (m_fHorizontal > 1f)
            {
                m_fHorizontal -= 0.1f;
                if (m_fHorizontal < 0.1f)
                    m_fHorizontal = 0;
            }
            else if(m_fHorizontal < -1f)
            {
                m_fHorizontal += 0.1f;            
                if (m_fHorizontal > 0.1f)
                {
                    m_fHorizontal = 0;
                }
            }
        }
        #endif

        Vector3 _MoveV3 =  new Vector3( m_fHorizontal * Time.deltaTime, 0 ,0 );
        #if UNITY_ANDROID && !UNITY_EDITOR
        _MoveV3 *= 4;
        #endif
        if (m_fHorizontal != 0)
            MainGameHost.MonoRef.InputCtrlOnMove(_MoveV3);

        if (Input.anyKey)
        {
            //Start bullet manager
            if (!m_isInputStart)
            {
                MainGameHost.MonoRef.BulletManagerSetEnabled(true);
                MainGameHost.MonoRef.TimeCtrlSetEnabled(true);
            }
            if (!m_LastState)
            {
                m_LastState = true;
                MainGameHost.MonoRef.TimeScaleCtrlSetSlowMotion(false);
                MainGameHost.MonoRef.BulletManagerSetDeltaTime();
            }
        }
        else if (m_LastState)
        {
            m_LastState = false;
            MainGameHost.MonoRef.TimeScaleCtrlSetSlowMotion(true);
            MainGameHost.MonoRef.BulletManagerSetDeltaTime();
        }
	}
}
