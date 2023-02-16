using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    public Plant Plant;
    public bool isNaturalSun;

    private void Start()
    {
        if (isNaturalSun)
        {
            GetComponent<Rigidbody>().drag = 5f;
            Destroy(gameObject, 20);
        }
        else
        {
            var direction = new Vector3(0, 0, -1);
            transform.forward = direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction.normalized * Plant.ProjectileForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(transform.up * Plant.ProjectileUpwardForce,
                ForceMode.Impulse);
            Destroy(gameObject, Plant.ProjectileLifeTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (name == "Sun" && other.gameObject.name != "Floor")
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
    }
}