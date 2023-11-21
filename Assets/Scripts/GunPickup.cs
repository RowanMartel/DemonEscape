using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    enum GunType
    {
        pistol,
        shotgun,
        rocketLauncher,
        machineGun,
        railGun
    }
    [SerializeField] GunType gunType;
    
    Player player;

    [SerializeField] Sprite pistolSprite;
    [SerializeField] Sprite shotgunSprite;
    [SerializeField] Sprite rocketLauncherSprite;
    [SerializeField] Sprite machineGunSprite;
    [SerializeField] Sprite railGunSprite;
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
            case GunType.railGun:
                gunImage.sprite = railGunSprite;
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
            case GunType.railGun:
                player.EquipGun(new RailGun());
                break;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}