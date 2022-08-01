using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]

public class Death : MonoBehaviour
{
    [SerializeField] private Transform _spawnPlayer;

    private Animator _animator;
    private int _animateDeath;

    public bool DeathPlayer { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        DeathPlayer = false;
        _animateDeath = Animator.StringToHash("Death");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _animator.SetTrigger(_animateDeath);
            DeathPlayer = true;

            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        var waitForTwoSeconds = new WaitForSeconds(2f);

        yield return waitForTwoSeconds;

        transform.position = _spawnPlayer.position;
        DeathPlayer = false;
    }
}
