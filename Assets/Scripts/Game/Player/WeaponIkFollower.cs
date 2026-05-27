using UnityEngine;

public class WeaponIkFollower : MonoBehaviour
{
    [SerializeField] private Transform _ikTarget;
    [SerializeField] private Transform _weaponTarget;

    private void LateUpdate()
    {
        _ikTarget.position = _weaponTarget.position;
        _ikTarget.rotation = _weaponTarget.rotation;
    }
}