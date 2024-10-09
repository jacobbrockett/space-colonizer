using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float projectileSpeed = 10.0f;
    
    [Header("Prefab")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Helpers")]
    [SerializeField] Transform spawnTransform;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource; // or GetComponent<AudioSource>()
    [SerializeField] AudioClip audioClip;
    [Range(0,1)]
    [SerializeField] float pitchRange = .2f;

    [Header("Ammo")]
    [SerializeField] int maxAmmo = 10;
    [SerializeField] int currentAmmo = 10;
    [SerializeField] float maxReloadTime = 10f;

    float currentReloadTime = 0;

    void Awake()
    {
        currentAmmo = maxAmmo;
    }

    
    // Launch a projectile Forward
    public float Launch(){ // return recoil amount
        if(currentAmmo < 1)
        {
            return 0f;
        }

        if(currentReloadTime > 0)
        {
            return 0f;
        }

        currentAmmo -= 1;

        GameObject newProjectile = Instantiate(projectilePrefab, spawnTransform.position, Quaternion.identity); // creates new projectile
        // newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0); // accessed projectile rigidbody and changed velocity

        // audioSource.PlayOneShot(audioClip); // unity can handle up to 32 audio clips for each audo source
        audioSource.Play();
        audioSource.pitch = Random.Range(1f-pitchRange, 1f+pitchRange);

        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;

        Destroy(newProjectile, 2); // destroy projectile after 30 seconds

        return GetRecoilAmount();
    }

    bool currentlyReloading = false;
    public void Reload()
    {
        if (currentlyReloading){
            return;
        }
        if (currentAmmo == maxAmmo)
        {
            return;
        }

        currentlyReloading = true;
        currentReloadTime = 0;
        StartCoroutine(ReloadRoutine());

        IEnumerator ReloadRoutine()
        {
            Debug.Log("Reload routine active!");
            // yield return new WaitForSeconds(reloadTime);

            while(currentReloadTime < maxReloadTime)
            {
                yield return null; // wait for a single frame
                currentReloadTime += Time.deltaTime;
            }

            currentReloadTime = 0;

            currentAmmo = maxAmmo;
            currentlyReloading = false;
            Debug.Log("Reload routine done!");
        }
    }

    public float GetReloadPercentage()
    {
        return currentReloadTime / maxReloadTime;
    }

    public float GetRecoilAmount()
    {
        return projectileSpeed * 2;
    }

    public int GetAmmo()
    {
        return currentAmmo;
    }

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }
}
