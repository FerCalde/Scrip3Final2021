
using UnityEngine;

public class ListsRewind
{
    public Vector3 position;
    public Quaternion rotation;
    public string estado;
    public float vida;
    public ListsRewind (Vector3 _position,Quaternion _rotation, string _estado, float _vida)
    {
        position = _position;
        rotation = _rotation;
        estado = _estado;
        vida = _vida;
    }
}
