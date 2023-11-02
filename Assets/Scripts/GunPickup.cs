using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    enum GunType
    {
        pistol,
        shotgun,
        rocketLauncher
    }
    [SerializeField] GunType gunType;
    
    Player player;

    [SerializeField] Sprite pistolSprite;
    [SerializeField] Sprite shotgunSprite;
    [SerializeField] Sprite rocketLauncherSprite;
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
        }
        Destroy(gameObject);
    }
}