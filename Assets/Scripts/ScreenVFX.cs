using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenVFX : MonoBehaviour
{
    [SerializeField] Image lowHealthImg;
    [SerializeField] Image doubleDamageImg;
    [SerializeField] Image infiniteAmmoImg;
    [SerializeField] Image invincibleImg;

    float lowHealthTimer;
    float lowHealthTime;
    bool lowHealthHardSet;

    float doubleDamageTimer;
    float doubleDamageTime;
    bool doubleDamageHardSet;

    float infiniteAmmoTimer;
    float infiniteAmmoTime;
    bool infiniteAmmoHardSet;

    float invincibleTimer;
    float invincibleTime;
    bool invincibleHardSet;

    public enum VFX
    {
        lowHealth,
        doubleDamage,
        infiniteAmmo,
        invincible
    }

    public void SetVFX(VFX vfx, float time = 0)
    {
        if (time > 0)
        {
            switch (vfx)
            {
                case VFX.lowHealth:
                    lowHealthImg.enabled = true;
                    lowHealthTime = time;
                    lowHealthTimer = 0;
                    break;
                case VFX.doubleDamage:
                    doubleDamageImg.enabled = true;
                    doubleDamageTime = time;
                    doubleDamageTimer = 0;
                    break;
                case VFX.infiniteAmmo:
                    infiniteAmmoImg.enabled = true;
                    infiniteAmmoTime = time;
                    infiniteAmmoTimer = 0;
                    break;
                case VFX.invincible:
                    invincibleImg.enabled = true;
                    invincibleTime = time;
                    invincibleTimer = 0;
                    break;
            }
        }
        else
        {
            switch (vfx)
            {
                case VFX.lowHealth:
                    lowHealthImg.enabled = true;
                    lowHealthHardSet = true;
                    break;
                case VFX.doubleDamage:
                    doubleDamageImg.enabled = true;
                    doubleDamageHardSet = true;
                    break;
                case VFX.infiniteAmmo:
                    infiniteAmmoImg.enabled = true;
                    infiniteAmmoHardSet = true;
                    break;
                case VFX.invincible:
                    invincibleImg.enabled = true;
                    invincibleHardSet = true;
                    break;
            }
        }
        
    }
    public void DisableVFX(VFX vfx)
    {
        switch (vfx)
        {
            case VFX.lowHealth:
                lowHealthImg.enabled = false;
                lowHealthHardSet = false;
                break;
            case VFX.doubleDamage:
                doubleDamageImg.enabled = false;
                doubleDamageHardSet = false;
                break;
            case VFX.infiniteAmmo:
                infiniteAmmoImg.enabled = false;
                infiniteAmmoHardSet = false;
                break;
            case VFX.invincible:
                invincibleImg.enabled = false;
                invincibleHardSet = false;
                break;
        }
    }

    private void Update()
    {
        if (lowHealthTimer < lowHealthTime)
            lowHealthTimer += Time.deltaTime;
        else if (lowHealthImg.enabled && !lowHealthHardSet)
            lowHealthImg.enabled = false;

        if (doubleDamageTimer < doubleDamageTime)
            doubleDamageTimer += Time.deltaTime;
        else if (doubleDamageImg.enabled && !doubleDamageHardSet)
            doubleDamageImg.enabled = false;

        if (infiniteAmmoTimer < infiniteAmmoTime)
            infiniteAmmoTimer += Time.deltaTime;
        else if (infiniteAmmoImg.enabled && !infiniteAmmoHardSet)
            infiniteAmmoImg.enabled = false;

        if (invincibleTimer < invincibleTime)
            invincibleTimer += Time.deltaTime;
        else if (invincibleImg.enabled && !invincibleHardSet)
            invincibleImg.enabled = false;
    }
}