using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenVFX : MonoBehaviour
{
    [SerializeField] Image lowHealthImg;
    [SerializeField] Image doubleDamageImg;
    [SerializeField] Image infiniteAmmoImg;
    [SerializeField] Image invincibleImg;

    [SerializeField] TMP_Text doubleDamageTxt;
    [SerializeField] TMP_Text infiniteAmmoTxt;
    [SerializeField] TMP_Text invincibleTxt;

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
                    doubleDamageTxt.enabled = true;
                    doubleDamageTime = time;
                    doubleDamageTimer = 0;
                    break;
                case VFX.infiniteAmmo:
                    infiniteAmmoImg.enabled = true;
                    infiniteAmmoTxt.enabled = true;
                    infiniteAmmoTime = time;
                    infiniteAmmoTimer = 0;
                    break;
                case VFX.invincible:
                    invincibleImg.enabled = true;
                    invincibleTxt.enabled = true;
                    invincibleTime = time;
                    invincibleTimer = 0;
                    break;
            }
        }// if time variable is set, turn off after the given time
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
                    doubleDamageTxt.enabled = true;
                    doubleDamageHardSet = true;
                    break;
                case VFX.infiniteAmmo:
                    infiniteAmmoImg.enabled = true;
                    infiniteAmmoTxt.enabled = true;
                    infiniteAmmoHardSet = true;
                    break;
                case VFX.invincible:
                    invincibleImg.enabled = true;
                    invincibleTxt.enabled = true;
                    invincibleHardSet = true;
                    break;
            }
        }
    }// enable the passed in VFX
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
                doubleDamageTxt.enabled = false;
                doubleDamageHardSet = false;
                break;
            case VFX.infiniteAmmo:
                infiniteAmmoImg.enabled = false;
                infiniteAmmoTxt.enabled = false;
                infiniteAmmoHardSet = false;
                break;
            case VFX.invincible:
                invincibleImg.enabled = false;
                invincibleTxt.enabled = false;
                invincibleHardSet = false;
                break;
        }
    }// disable the passed in VFX

    private void Update()
    {
        if (lowHealthTimer < lowHealthTime)
            lowHealthTimer += Time.deltaTime;
        else if (lowHealthImg.enabled && !lowHealthHardSet)
            lowHealthImg.enabled = false;

        if (doubleDamageTimer < doubleDamageTime)
            doubleDamageTimer += Time.deltaTime;
        else if (doubleDamageImg.enabled && !doubleDamageHardSet)
        {
            doubleDamageImg.enabled = false;
            doubleDamageTxt.enabled = false;
        }

        if (infiniteAmmoTimer < infiniteAmmoTime)
            infiniteAmmoTimer += Time.deltaTime;
        else if (infiniteAmmoImg.enabled && !infiniteAmmoHardSet)
        {
            infiniteAmmoImg.enabled = false;
            infiniteAmmoTxt.enabled = false;
        }

        if (invincibleTimer < invincibleTime)
            invincibleTimer += Time.deltaTime;
        else if (invincibleImg.enabled && !invincibleHardSet)
        {
            invincibleImg.enabled = false;
            invincibleTxt.enabled = false;
        }
    }// disable timer-based VFX over time
}