using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 1f;
    private Transform _target;

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}
