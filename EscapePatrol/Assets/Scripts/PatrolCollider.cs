using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //print("enter");
            //玩家进入侦察兵追捕范围
            this.gameObject.transform.parent.GetComponent<PatrolData>().follow_player = true;
            this.gameObject.transform.parent.GetComponent<PatrolData>().player = collider.gameObject;
        }
    }
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 40;
        style.normal.textColor = Color.red;
        if(this.gameObject.transform.parent.GetComponent<PatrolData>().follow_player == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 400, 500), "!!You Have Been Found!!", style);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<PatrolData>().follow_player = false;
            this.gameObject.transform.parent.GetComponent<PatrolData>().player = null;
        }
    }
}
