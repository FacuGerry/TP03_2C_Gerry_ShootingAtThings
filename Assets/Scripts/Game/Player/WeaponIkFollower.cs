using UnityEngine;

public class WeaponIkFollower : MonoBehaviour
{
    [SerializeField] private Transform _ikTarget;
    [SerializeField] private Transform _weaponTarget;

    private void LateUpdate()
    {
        _ikTarget.SetPositionAndRotation(_weaponTarget.position, _weaponTarget.rotation);
    }
}