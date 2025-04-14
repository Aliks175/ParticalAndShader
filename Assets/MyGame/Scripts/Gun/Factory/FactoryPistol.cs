using UnityEngine;

[CreateAssetMenu(fileName = "FactoryPistol",menuName = "Factory/Weapon/FactoryPistol")]
public class FactoryPistol : FactoryWeapon
{
    [SerializeField] private FactoryBullet _factoryBullet;

    [SerializeField] private float _forceBullet;

    public override Weapon CreateWeapon(Transform startPos)
    {
        _factoryBullet.Initsiolaze();
        return new Pistol(_factoryBullet,startPos,_forceBullet);
    }
}
