using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletPrefab;

    private BerryUI berryUI;
    private bool hasClickedOnce = false;

    void Start()
    {
        berryUI = FindFirstObjectByType<BerryUI>();

        if (target != null)
        {
            target.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (!hasClickedOnce)
            {
                hasClickedOnce = true;

                if (target != null)
                {
                    target.SetActive(true);
                }
            }

            
            if (berryUI == null || !berryUI.TryUseBerry(1))
            {
                Debug.Log("Not enough berries to shoot.");
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                

                Vector2 projecttileVelocity = CalculateProjectileValocity(shootPoint.position, hit.point, 1f);
                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                shootBullet.linearVelocity = projecttileVelocity;
            }
        }
    }

    Vector2 CalculateProjectileValocity(Vector2 origin, Vector2 target, float time) 
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

        return projectileVelocity;
    }
}
