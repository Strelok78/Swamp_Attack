using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
    private Player _target;
    private Animator _animator;
    private PolygonCollider2D _polygonCollider;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _animator.Play("Hit");

        if(_health <= 0)
        {
            _polygonCollider.enabled = false;
            _animator.Play("Dead");
            Dying?.Invoke(this);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
