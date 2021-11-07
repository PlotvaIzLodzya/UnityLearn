using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public GuardScript Player;
    public float ReturnSpeed;
    public Shooter Shooter1;
    public Shooter Shooter2;
    public ParticleSystem HealEffect;

    private int _shootCount;
    private Transform _companionPlace;

    void Start()
    {
        _companionPlace = Player.CompanionPlace;
    }

    void Update()
    {
        FollowingCharacter();

        if (Input.GetMouseButtonDown(0))
        {
            if(transform.position.x < Player.transform.position.x)
            {
                Shooter1.SetScale(1);
                Shooter2.SetScale(1);
            }
            else
            {
                Shooter1.SetScale(-1);
                Shooter2.SetScale(-1);
            }

            if(_shootCount%2 == 0)
            {
                Shooter1.Emit();
                _shootCount++;
            }
            else
            {
                Shooter2.Emit();
                _shootCount = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            HealEffect.Play();
        }

    }

    private void FollowingCharacter()
    {
        if(transform.position != _companionPlace.position)
        {
            transform.position = Vector3.Lerp(transform.position, _companionPlace.position, ReturnSpeed * Time.deltaTime);
        }
    }
}
