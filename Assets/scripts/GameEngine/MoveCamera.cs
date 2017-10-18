using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MoveCamera : MonoBehaviour {
    public GameObject cam;
    public Vector2 nextPos;
    public Vector3 drawFigure;

    void Start() {
        cam = GameObject.Find("Camera");
        this.GetComponent<BoxCollider>().size = drawFigure;
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position, drawFigure);
    }

    public void OnTriggerEnter(Collider C) {
        if (C.gameObject.layer == LayerMask.NameToLayer("Character"))
            cam.transform.position = new Vector3 (nextPos.x, 24, nextPos.y);
    }
}
