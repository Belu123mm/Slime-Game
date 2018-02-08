using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour {
    //ESta clase crea un dibujo que marca el camino entre los puntos
    //Se debe indicar su color y la cantidad de puntos que hay en este camino.
    public int count;
    public Color color;
    void Start() {
    }
    void OnDrawGizmos() {
        Gizmos.color = color;

        for (int i = 0; i < count -1; i++) {
                Gizmos.DrawLine(this.gameObject.transform.GetChild(i).position, this.gameObject.transform.GetChild(i + 1).position);
                Gizmos.DrawLine(this.gameObject.transform.GetChild(count -1).position, this.gameObject.transform.GetChild(0).position);
        }
    }
}
