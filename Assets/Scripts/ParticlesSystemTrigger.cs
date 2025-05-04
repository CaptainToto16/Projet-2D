using UnityEngine;
using System.Collections;

public class ParticlesSystemTrigger : MonoBehaviour
{
    public ParticleSystem targetParticleSystem;

    public void TriggerParticles(float duration)
    {
        if (targetParticleSystem != null)
        {
            targetParticleSystem.Play();
            StopAllCoroutines();
            StartCoroutine(StopAfterDelay(duration));
        }
    }

    private IEnumerator StopAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetParticleSystem.Stop();
    }
}