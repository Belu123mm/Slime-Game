using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsPw : basePW {
    public delegate void StatsFunction();
    public Dictionary<PWTYPE, StatsFunction> SetPowerUp = new Dictionary<PWTYPE, StatsFunction>();
    public PWTYPE selectPowerUp;
    public int powerUpValue;

    public void Awake() {
        slimeHero = FindObjectOfType<slimeScript>();        
    }

    public void Start() {
        SetPowerUp [ PWTYPE.healing ] = Healing;
        SetPowerUp [ PWTYPE.coins ] = Coins;
        SetPowerUp [ PWTYPE.velocityBuff ] = Velocity;
        SetPowerUp [ PWTYPE.damangeBuff ] = DmgBuff;
        SetPowerUp [ PWTYPE.delayBuff ] = DelayBuff;
        SetPowerUp [ PWTYPE.bulletsVelocityBuff ] = BulletsVelocityBuff;
        SetPowerUp [PWTYPE.poison] = PoisonDebuff;
        SetPowerUp[PWTYPE.bomb] = Bomb;

    }
    public override void PwBehaviour() {
        SetPowerUp [ selectPowerUp ].Invoke();
        base.PwBehaviour();
    }

    public void Healing() {
        slimeHero.Healing(powerUpValue);
        slimeHero.RefreshHpBar();
    }
    public void Coins() {
        slimeHero.coins += powerUpValue;
    }
    public void Velocity() {
        slimeHero.speed += powerUpValue;
        slimeHero.addedSpeed += powerUpValue;
        slimeHero.pwActive = true;
    }
    public void DmgBuff() {
        slimeHero.dmg += powerUpValue;
        slimeHero.RefreshBullet();
        slimeHero.addedDmg += powerUpValue;
        slimeHero.pwActive = true;
    }
    public void DelayBuff() {
        slimeHero.restDelay += (powerUpValue / 10);
        slimeHero.RefreshBullet();
    }
    public void BulletsVelocityBuff() {
        slimeHero.addedSpeed += powerUpValue;
        slimeHero.RefreshBullet();
    }
    public void PoisonDebuff()
    {
        slimeHero.hp -= powerUpValue;
    }
    public void Bomb()
    {
        slimeHero.bomb = true;
    }
}

public enum PWTYPE {
    bomb,
    poison,
    healing,
    coins,
    // slowEnemies,
    velocityBuff,
    damangeBuff,
    delayBuff,
    bulletsVelocityBuff,
}
