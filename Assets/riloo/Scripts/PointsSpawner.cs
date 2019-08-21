
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    public GameObject prefab;

    private GameObject ins;

    private Rigidbody2D rb;

    private Vector3 direction, v;

    private float degreeForPoint;

    public float force = 100;

    public bool spawn = false;

    public uint test = 10;

    public void SpawnPoints(uint count, float lengthSpawn = 0.05f)
    {
        degreeForPoint = 360f / count;

        for (int i = 0; i < count; i++)
        {
            ins = Instantiate(prefab, transform.position, transform.rotation);

            v = transform.position;

            direction.x = Mathf.Sin(degreeForPoint * i * Mathf.Deg2Rad);
            direction.y = Mathf.Cos(degreeForPoint * i * Mathf.Deg2Rad);

            rb = ins.GetComponent<Rigidbody2D>();

            foreach (var item in ins.GetComponentsInChildren<MaterialColorChange>())
            {
                item.FillColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }

            v += direction * lengthSpawn;
            v.z = -1f;

            ins.transform.position = v;

            rb.AddForce(direction * Random.Range(force / 2, force));
        }
    }

    //private void Update()
    //{
    //    if (spawn)
    //    {
    //        spawn = false;

    //        SpawnPoints(test);
    //    }
    //}
}
