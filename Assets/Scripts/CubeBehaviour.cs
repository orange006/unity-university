using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public GameObject Cube;

    private float MaxVal = 10;
    private float _sign = 1;
    private float x;

    void Update()
    {
        x += _sign * Time.deltaTime * 5;

        Cube.transform.localScale = new Vector3(x, 2, 2);
        Cube.transform.rotation = Quaternion.Euler(0, x, 0);

        if (MaxVal <= Cube.transform.localScale.magnitude)
        {
            _sign *= -1;
        }
    }
}
