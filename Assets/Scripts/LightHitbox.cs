using System;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    
        public GameObject lightAttackHitbox;
    public GameObject HeavyHitbox;  

        public void EnableLightHitbox()
        {
            lightAttackHitbox.SetActive(true);
        }

        public void DisableLightHitbox()
        {
            lightAttackHitbox.SetActive(false);
        }

        public void EnableHeavyHitbox()
        {
            HeavyHitbox.SetActive(true);
        }

        public void DisableHeavyHitbox()
        {
            HeavyHitbox.SetActive(false);
        }
    }



