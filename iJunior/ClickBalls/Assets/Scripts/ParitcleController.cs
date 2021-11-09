using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallRender),typeof(Ball))]
public class ParitcleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    private Ball _ball;
    private BallRender _render;

    [System.Obsolete]
    private void Start()
    {
        _render = GetComponent<BallRender>();
        _particles.Pause();
        _particles.startColor = _render.Color;
    }

    private void OnEnable()
    {
        _ball = GetComponent<Ball>();
        _ball.Poped += Play;
    }

    private void OnDisable()
    {
        _ball.Poped -= Play;
    }

    private void Play(int particleAmount)
    {
        _particles.transform.parent = null;
        _particles.Emit(particleAmount);
    }
}
