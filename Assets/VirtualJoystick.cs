using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class VirtualJoystick : MonoBehaviour {

    public float speed = 10;
	public void Update () {
        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        float translationH = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        translationH *= Time.deltaTime;
        transform.Translate(translationH, 0, 0);

        if (CrossPlatformInputManager.GetButtonDown("Bomb"))
            GetComponent<slimeScript>().Bomb();
    }

    public static bool IsTouching(int id)
    {
        if (Input.touchCount > id)
        {
            if (Input.GetTouch(id).phase == TouchPhase.Began) return true;

            else if (Input.GetTouch(id).phase == TouchPhase.Moved) return true;

            else if (Input.GetTouch(id).phase == TouchPhase.Stationary) return true;

            else return false;
        }
        else return false;
    }
    public static bool IsRealised(int id)
    {
        if (Input.touchCount > id && (Input.GetTouch(id).phase == TouchPhase.Ended ||
            Input.GetTouch(id).phase == TouchPhase.Canceled))
        {
            return true;
        }
        else return false;
    }

    public static Vector2 GetDirection()
    {
        if (IsTouching(0))
        {
            Vector2 dir = Input.GetTouch(0).deltaPosition.normalized;
            dir.x = Mathf.RoundToInt(dir.x);
            dir.y = Mathf.RoundToInt(dir.y);
            return dir;
        }
        else return Vector2.zero;
    }

    public static Ray GetRay()
    {
        if (IsTouching(0))
        {
            Vector3 pos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(pos);

            return ray;
        }
        else return new Ray();
    }
}
