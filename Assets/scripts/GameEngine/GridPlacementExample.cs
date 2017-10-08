using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GridPlacementExample : MonoBehaviour {

    public float xGridScale = 1;
    public float yGridScale = 1;
    public float zGridScale = 1;
    public Material errorM;
    public int gridScale;
    void Update() {
        Transform[] childrens = GetComponentsInChildren<Transform>(); // Tomamos todos sus hijos
        if (Application.isEditor) // Nos aseguramos de que sea solamente de editor
        {
            for (int i = childrens.Length - 1; i >= 0; i--) // Recorremos la lista de hijos
            {
                Vector3 currentPosition = childrens[i].position; // Almacenamos su posicion
                float xDifference = currentPosition.x % xGridScale; // Calculamos la diferencia en x
                float yDifference = currentPosition.y % yGridScale; // Calculamos la diferencia en y
                float zDifference = currentPosition.z % zGridScale; // Calculamos la diferencia en z
                childrens[i].transform.position = new Vector3(
                    currentPosition.x - xDifference,
                    currentPosition.y - yDifference,
                    currentPosition.z - zDifference); // Reposicionamos al objeto
            }
            for (int i = 0; i < childrens.Length; i++) {
                for (int j = 0; j < childrens.Length; j++) {
                    //If position j = position i
                    //Acceder al material del childrens[j]
                }
            }
        }
        float xCalc = xGridScale / 2;
        float yCalc = yGridScale / 2;
        float zCalc = zGridScale / 2;
        for (int i = 0; i < gridScale; i++) {
            if (gridScale % 2 == 0) 
                gridScale++;
        //Verticales
        Debug.DrawLine(new Vector3(-xCalc + i * xGridScale, 10, -zCalc + i * zGridScale), new Vector3(-xCalc + i * xGridScale, 10, zCalc + i * zGridScale));
        Debug.DrawLine(new Vector3( xCalc + i * xGridScale, 10,  zCalc + i * zGridScale), new Vector3( xCalc + i * xGridScale, 10,-zCalc + i * zGridScale));
        //Horizontales
        Debug.DrawLine(new Vector3(-xCalc + i * xGridScale, 10,  zCalc + i * zGridScale), new Vector3( xCalc + i * xGridScale, 10, zCalc + i * zGridScale));
        Debug.DrawLine(new Vector3( xCalc + i * xGridScale, 10, -zCalc + i * zGridScale), new Vector3(-xCalc + i * xGridScale, 10,-zCalc + i * zGridScale));
            

        }
    }
    void OnDrawGizmos() {

    }
}
