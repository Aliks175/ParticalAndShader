using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactoryArtilleryCore", menuName = "Factory/Bullet/FactoryArtilleryCore")]
public class FactoryArtilleryCore : FactoryBullet
{
    [SerializeField] private GameObject _prefbullet;
    [SerializeField] private int _createBulletAwake = 5;
    private List<BulletCore> _bulletList;

    public override void Initsiolaze()
    {
        _bulletList.Clear();
        Create(_createBulletAwake);
    }

    public override BulletCore GetBullet()
    {
        BulletCore bullet;
        if (FindFreeBullet(out BulletCore freebullet))
        {
            bullet = freebullet;
        }
        else
        {
            Create(_bulletList.Count / 2);
            bullet = GetBullet();
        }
        return bullet;
    }

    private bool FindFreeBullet(out BulletCore freebullet)
    {
        freebullet = null;
        bool isSuccess = false;
        for (int i = 0; i < _bulletList.Count; i++)
        {
            if (_bulletList[i].gameObject.activeSelf == false)
            {
                freebullet = _bulletList[i];
                isSuccess = true;
                return isSuccess;
            }
        }
        return isSuccess;
    }

    private void Create(int value)
    {
        for (int i = 0; i < value; i++)
        {
            var Bullet = GameObject.Instantiate(_prefbullet, Vector3.zero, Quaternion.identity);
            var BulletCore = Bullet.GetComponent<BulletCore>();
            BulletCore.Initsialize();
            _bulletList.Add(BulletCore);
            Bullet.SetActive(false);
        }
    }

    private void Reset()
    {
        _bulletList.Clear();
    }
}
