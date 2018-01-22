using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemy : MonoBehaviour {
    public int vida;
    public GameObject batModel;
    public ENEMYTYPE eType;
    public Material [] enemyMaterial;
    public Material currMaterial;

    // Use this for initialization
    public virtual void Awake() {

    }
    public virtual void Start() {
        Invoke("Set" + eType, 0);

    }// Update is called once per frame
    public virtual void Update() {
        batModel.GetComponent<Renderer>().material = currMaterial;//En start esto no anda :V es raro, check it

    }
    public enum ENEMYTYPE {
        Easy,
        Medium,
        Hard,
    }
    public virtual void SetEasy() { //Velocidad, puntos, vida
        print("easy");
        currMaterial = enemyMaterial [ 0 ];
    }
    public virtual void SetMedium() {
        print("medium");
        currMaterial = enemyMaterial [ 1 ];
    }
    public virtual void SetHard() {
        print("hard");
        currMaterial = enemyMaterial [ 2 ];
    }
}
