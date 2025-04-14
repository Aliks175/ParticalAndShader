using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletCore : MonoBehaviour
{
    [SerializeField] private float _time = 2f;
    [HideInInspector]public Rigidbody _body;

    private void OnEnable()
    {
        StartCoroutine(TimeDisable());
    }

    private void OnDisable()
    {
        _body.angularVelocity=Vector3.zero;
        _body.linearVelocity=Vector3.zero;
        StopCoroutine(TimeDisable());
    }

    public void Initsialize()
    {
        _body = GetComponent<Rigidbody>();
    }

    private IEnumerator TimeDisable()
    {
        yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
    }
}
