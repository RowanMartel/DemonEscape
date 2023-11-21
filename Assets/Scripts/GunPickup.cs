using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    enum GunType
    {
        pistol,
        shotgun,
        rocketLauncher,
        machineGun
    }
    [SerializeField] GunType gunType;
    
    Player player;

    [SerializeField] Sprite pistolSprite;
    [SerializeField] Sprite shotgunSprite;
    [SerializeField] Sprite rocketLauncherSprite;
    [SerializeField] Sprite machineGunSprite;
    [SerializeField] Image gunImage;

    void Start()
    {
        player = FindObjectOfType<Player>();

        switch (gunType)
        {
            case GunType.pistol:
                gunImage.sprite = pistolSprite;
                break;
            case GunType.shotgun:
                gunImage.sprite = shotgunSprite;
                break;
            case GunType.rocketLauncher:
                gunImage.sprite = rocketLauncherSprite;
                break;
            case GunType.machineGun:
                gunImage.sprite = machineGunSprite;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerCapsule")) return;
        switch (gunType)
        {
            case GunType.pistol:
                player.EquipGun(new Pistol());
                break;
            case GunType.shotgun:
                player.EquipGun(new Shotgun());
                break;
            case GunType.rocketLauncher:
                player.EquipGun(new RocketLauncher());
                break;
            case GunType.machineGun:
                player.EquipGun(new MachineGun());
                break;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}