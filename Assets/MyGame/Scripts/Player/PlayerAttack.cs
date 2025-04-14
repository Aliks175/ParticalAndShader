using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _positionWeapon;
    [SerializeField] private FactoryWeapon _factoryWeapon;
    private Weapon _weapon;

    private void Start()
    {
        _weapon = _factoryWeapon.CreateWeapon(_positionWeapon);
    }

    public void Attack()
    {
        _weapon.Attack();
    }
}
