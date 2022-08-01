using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Frog : MonoBehaviour
{
    [SerializeField] private float _speedAnimation = 1f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = _speedAnimation;
    }
}
