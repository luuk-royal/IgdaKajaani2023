using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireblower : MonoBehaviour
{
    public ER_GameManager gameManager;
    public ParticleSystem firePS;
    public float fireDir = 0;

    private void Update()
    {
        if (gameManager.gameOver) return;
        firePS.transform.Rotate(new Vector3(0, 0, Mathf.Clamp(fireDir, -85, 85)));
    }
}
