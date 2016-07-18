using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour {

    private float m_fHorizontal             = 0;

    private PlayerControl m_Player          = null;
    private BulletManager m_BulletManager   = null;
    private TimeScaleCtrl m_TimeScaleCtrl   = null;
    private TimerControl  m_TimeControl     = null;

    private int m_iScreenW = 0;

    private bool m_isInputStart = false;

	void Start () {
        m_iScreenW = Screen.width;
        m_Player = PlayerControl.Ctrl;
        m_BulletManager = BulletManager.Manager;
        m_TimeScaleCtrl = TimeScaleCtrl.Ctrl;
        m_TimeControl = TimerControl.Ctrl;
	}
	
	void Update () 
    {
        m_fHorizontal = Input.GetAxis("Horizontal");
        #if UNITY_ANDROID
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
        m_Player.Move( _MoveV3 );

        if (Input.anyKey)
        {
            //Start bullet manager
            if (!m_isInputStart)
            {
                m_BulletManager.SetEnable(true);
                m_TimeControl.SetEnabled(true);
            }
            
            m_TimeScaleCtrl.SetSlowMotion(false);
//            m_TimeScaleCtrl.SetTimeScaleByDelta( m_fHorizontal );
        }
        else
        {
            m_TimeScaleCtrl.SetSlowMotion(true);
        }
	}
}
