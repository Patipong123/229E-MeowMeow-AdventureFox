using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform currentTarget;

    void Start()
    {
        currentTarget = pointB;

        if (Vector2.Distance(transform.position, pointA.position) < Vector2.Distance(transform.position, pointB.position))
            currentTarget = pointB;
        else
            currentTarget = pointA;
    }

    void Update()
    {
        if (currentTarget == null) return;

        
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        Vector3 scale = transform.localScale;
        if (currentTarget.position.x > transform.position.x)
            scale.x = Mathf.Abs(scale.x);
        else
            scale.x = -Mathf.Abs(scale.x);

        transform.localScale = scale;


        if (Vector2.Distance(transform.position, currentTarget.position) < 0.5f)
        {
            
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
}
