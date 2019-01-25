﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : Weapon
{
    public ParticleSystem AttackIdleParts;
    public SpriteRenderer SwordImage;
    public Color IdleStateColor;
    public Color AttackStateColor;
    public bool ISKOSTULTOCHECKERBODYPART;

    public override void Attack(ICanGetDamage damagedObject)
    {
        damagedObject.GetDamage(Damage,this);
        SetColdown();
    }
    private void Update()
    {
        if (!IsHandleNow)
            return;

        SwordImage.color = IdleStateColor;
        if (IsAttackingNow)
        {
            if (IsColdownedNow())
            {
                ShowFightReadyVFX();
                SwordImage.color = AttackStateColor;
            }
        }
    }

    public override void ShowFightReadyVFX()
    {
        AttackIdleParts.Emit(5);
    }

    public override void Throw(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsHandleNow)
        {
            if (collision.tag == "Player")
            {   
                collision.GetComponent<PlayerWeaponController>().CatchWeapon(this);
                Debug.Log("<color=red><b> HANDLE </b></color>");
            }
        }
       


        if (!IsAttackingNow || !IsColdownedNow())
            return;


        if (collision.tag == "Damagable")
        {   

            if (PlayerWeaponController != null)
            {
                    ICanGetDamage damagedObject = collision.GetComponent<ICanGetDamage>();
                //КОСТЫЛЬ ГОДА
                if (ISKOSTULTOCHECKERBODYPART)
                {
                    if (damagedObject != null && PlayerWeaponController.PlayerStateController.IsCurrentPlayerBodyPart(damagedObject))
                    {
                        Attack(collision.GetComponent<ICanGetDamage>());
                        // Debug.Log(gameObject.name + "<color=orange><b> ТАЧ </b></color>" + collision.name);
                    }
                }
                else
                {
                    if (damagedObject != null && !PlayerWeaponController.PlayerStateController.IsCurrentPlayerBodyPart(damagedObject))
                    {
                        Attack(collision.GetComponent<ICanGetDamage>());
                        // Debug.Log(gameObject.name + "<color=orange><b> ТАЧ </b></color>" + collision.name);
                    }
                }

            }


        }
    }
}