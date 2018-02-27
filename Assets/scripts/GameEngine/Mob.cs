using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {
    //Esta es la clase maestra, con la que se generan todos los seres de este juego. 
    //Cada uno tiene vida, daño, velocidad y su tiempo para ser lastimados.
    //Tiene las funciones de colision entre melees y balas. 
    //Estas funciones se colocan SOLO en la victima, como por ejemplo en el slimeHero o el enemigo
    //El tiempo se debe reiniciar cada vez que hay daño. 
    //   [HideInInspector]
    public float hp;
    public int dmg,
               speed;
    public int timeToHurt;
    public float timer;
    public AudioClip hurtSound,
                     idleSound;
    Mob mInstance;
    Bullets bInstance;

    public virtual void Update()
    {
        timeToHurt = 2;
        timer += 1 * Time.deltaTime;
        if (hp <= 0 ) {
            Death();
        }
    }
    public virtual void OnCollisionEnter( Collision c ) {
    }
    public virtual void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Bullets"))
        {
            bInstance = c.gameObject.GetComponent<Bullets>();
            RangeDamage(bInstance, this);
        }
    }
    public virtual void MeleeDamage(Mob atac, Mob vict)
    {
        print(atac);
        int newDmg = atac.dmg;
        vict.hp -= newDmg;
        ResetTime();
    }
    public virtual void RangeDamage(Bullets atac, Mob vict)
    {
        int newDmg = atac.dmg;
        vict.hp -= newDmg;
    }
    public void ResetTime()
    {
        timer = 0;
    }
    public void StartLife(int qt)
    {
        hp = qt;
    }
    public void Healing(int qt)
    {
        hp += qt;
    }
    public virtual void Death() {

    }
}
