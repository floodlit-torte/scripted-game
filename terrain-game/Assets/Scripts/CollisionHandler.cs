using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem DamageVFX;

    private void OnCollisionEnter(Collision collision)
    {
        DamageVFX.Play();
    }
}
