
using UnityEngine;

public class ListsRewindBalas
{
    public Vector3 position;
    public bool activo;
    public float time;
    public float speed;
    public ListsRewindBalas(Vector3 _position, float _Time, bool _activo, float _speed)
    {
        position = _position;
        time = _Time;
        activo = _activo;
        speed = _speed;
    }
}
