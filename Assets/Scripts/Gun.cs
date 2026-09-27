using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.PlayerLoop;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletHoleDecal;
    [SerializeField] TMP_Text ammoCountText;
    [SerializeField] Camera playerCamera;
    [SerializeField] LayerMask shootableLayer;
    [SerializeField] int magzineSize = 30;
    [SerializeField] float gunRange;
    [SerializeField] int gunDammage;
    [SerializeField] float roundsPerMinute = 400f;

    float timeBetweenShots;

    float shootTimer = 0f;
    int currentAmmo;
    bool isReloading;
    [SerializeField] float reloadTime = 2f;
    void Start()
    {
        currentAmmo = magzineSize;
        timeBetweenShots = 1 / (roundsPerMinute / 60);
        shootTimer = timeBetweenShots;
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
        HandleReloading();
    }

    private void HandleShooting()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && currentAmmo > 0 && shootTimer > timeBetweenShots && !isReloading)
        {
            RaycastHit hit;

            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * gunRange, Color.blue);

            if (Physics.Raycast(ray, out hit, gunRange, shootableLayer))
            {
                GameObject decal = Instantiate(bulletHoleDecal, hit.point, Quaternion.LookRotation(hit.normal));
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage(gunDammage);
                }

                Destroy(decal, 6f);
                Debug.Log(hit.collider.name);
            }

           
            shootTimer = 0f;
            currentAmmo--;
            UpdateAmmoUI();
        }
    }

    private void HandleReloading()
    {
        if(Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo < magzineSize)
        {
            StartCoroutine(ReloadRoutine());
        }
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magzineSize;
        isReloading = false;
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        ammoCountText.text = $"Ammo : {currentAmmo}/{magzineSize}";
    }

    
    
}
