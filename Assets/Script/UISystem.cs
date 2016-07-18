using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISystem : MonoBehaviour {

    public Text m_TimeLabel = null;

    public void SetTimeLabelText( string _text )
    {
        m_TimeLabel.text = _text;
    }
	
}
