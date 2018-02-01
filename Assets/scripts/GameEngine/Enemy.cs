using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mob {
    //Esta es una clase que ve los enemigos, en donde se ve su cambio de material, se setea su dificultad y se nivelan sus valores
    //
    public GameObject model;
    public ENEMYTYPE eType;
    public Material [] enemyMaterial;
    public Material currMaterial;

    public enum ENEMYTYPE {
        Easy,
        Medium,
        Hard,
    }

    public virtual void Awake() {

    }

    public virtual void Start() {
        Invoke("Set" + eType, 0);
    }
    public override void Update() {
        base.Update();
        model.GetComponent<Renderer>().material = currMaterial;//En start esto no anda :V es raro, check it
    }


    //Velocidad, puntos, vida
    public virtual void SetEasy() { 
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
