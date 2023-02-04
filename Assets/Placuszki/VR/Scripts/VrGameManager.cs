using UnityEngine;

namespace Placuszki.VR.Scripts
{
    public class VrGameManager : MonoBehaviour
    {
        [SerializeField] private ProjectileSpawner projectileSpawner;
        [SerializeField] private float delayBeforeSpawningNextProjectile = 1;

        private Projectile _currentSpawnedProjectile;

        private void Start()
        {
            SpawnNewProjectile();
        }

        private void SpawnNewProjectile()
        {
            _currentSpawnedProjectile = projectileSpawner.SpawnNewProjectile();
            _currentSpawnedProjectile.OnProjectileGrabbed.AddListener(ProjectileGrabbed);
        }

        private void ProjectileGrabbed()
        {
            if (_currentSpawnedProjectile != null)
            {
                _currentSpawnedProjectile = null;
                Invoke(nameof(SpawnNewProjectile), delayBeforeSpawningNextProjectile);
            }
        }
    }
}