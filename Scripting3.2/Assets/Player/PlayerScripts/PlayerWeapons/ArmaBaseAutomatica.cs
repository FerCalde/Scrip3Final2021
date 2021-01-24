using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBaseAutomatica : ArmaBase
{

    bool isDisparando = false;

    private void Update()
    {
        if (isDisparando)
        {
            Disparar();
            BulletScreen();

            if (autoReloading)
            {
                if (currentAmmo <= 0)
                {
                    GetComponentInParent<WeaponController>().autoReloadController();
                    GetComponentInParent<WeaponController>().StartReload(tiempoRecarga);
                }
            }
        }
    }

    public override void ApretarGatillo()
    {
        ComenzarDisparos();
    }
    public override void SoltarGatillo()
    {
        DetenerDisparos();
    }

    void ComenzarDisparos()
    {
        isDisparando = true;
    }

    void DetenerDisparos()
    {
        isDisparando = false;
    }
}
