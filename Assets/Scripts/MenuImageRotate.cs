using UnityEngine;
using UnityEngine.UI;

public class MenuImageRotate : MonoBehaviour
{
    public int _speed;
    Vector3 rotationEuler;
    public Image _image;
    private float _randspeed;
    private void Start()
    {
        do
        {
            _randspeed = Random.Range(-1f, 1f);
        } while (_randspeed >= 0.3f || _randspeed <= -0.3f);
    }
    void Update()
    {
        rotationEuler += Vector3.forward * _speed/50 * _randspeed;
        _image.transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
