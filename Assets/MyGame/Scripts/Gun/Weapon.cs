using UnityEngine;

public interface Weapon
{
    public void Attack();
}

public class Pistol : Weapon
{
    private FactoryBullet _factoryBullet;
    private float _forceBullet;
    private Transform _startPos;

    public Pistol(FactoryBullet factoryBullet, Transform startPos, float forceBullet)
    {
        _factoryBullet = factoryBullet;
        _startPos = startPos;
        _forceBullet = forceBullet;
    }

    public void Attack()
    {
        var bullet = _factoryBullet.GetBullet();
        bullet.transform.position = _startPos.position;
        bullet.gameObject.SetActive(true);
        bullet._body.AddForce(_startPos.forward * _forceBullet, ForceMode.Impulse);
    }
}

public abstract class FactoryWeapon : ScriptableObject
{
    public abstract Weapon CreateWeapon(Transform startPos);
}

public abstract class FactoryBullet : ScriptableObject
{
    public virtual void Initsiolaze() { }

    public abstract BulletCore GetBullet();
}