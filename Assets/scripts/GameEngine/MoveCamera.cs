using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MoveCamera : MonoBehaviour {
    //Esta clase se usa para crear los colliders entre puertas para que la camara se mueva de habitacion en habitacion
    //drawfigure crea, segun lo que uno marque en el objeto, un cubo de color rojo
    //Esa forma roja tambien es un collider. 
    //nextPos es el vector hacia donde se movera la siguiente habitacion, siendo  24 siempre la misma altura de la camara
    //El personaje al chocar con ese collider se mueve a la siguiente habitacion
    //Este objeto SIEMPRE debe tener el pag CameraMovement
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
        cam.transform.position = new Vector3 (nextPos.x, 24, nextPos.y);
    }
}
