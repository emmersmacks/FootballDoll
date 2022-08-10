using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int currentIteration = 0;
    private int currentWave = 1;
    private System.Random _random = new System.Random();

    [SerializeField] private List<BallShooterController> _ballShooters = new List<BallShooterController>();
    [SerializeField] private AnimationCurve _LevelWaveCurve;
    [SerializeField] private AnimationCurve _ShootDelayCurve;

    [SerializeField] private float BombChanceInPercent;
    [SerializeField] private float MoneyBallChanceInPercent;

    private void Start()
    {
        StartWave();
    }

    private async UniTask StartWave()
    {
        while(true)
        {
            currentIteration++;
            var index =_random.Next(_ballShooters.Count);
            var ballShooter = _ballShooters[index];
            var timeDelay = _ShootDelayCurve.Evaluate(currentIteration);

            for (var i = 1; i < _LevelWaveCurve.Evaluate(currentIteration); i++)
            {
                Shoot(ballShooter, timeDelay);
                await UniTask.Delay((int)(timeDelay * 1000) / 2);
            }
            await Shoot(ballShooter, timeDelay);

        }
    }

    private async UniTask Shoot(BallShooterController ballShooter, float timeDelay)
    {
        if (CheckChance(BombChanceInPercent))
        {
            await ballShooter.ShootBomb(timeDelay);
        }
        else if (CheckChance(MoneyBallChanceInPercent))
        {
            await ballShooter.ShootMoney(timeDelay);
        }
        else
        {
            await ballShooter.ShootBall(timeDelay);
        }
    }

    private bool CheckChance(float percent)
    {
        var percentIndex = _random.Next(100);
        if (percentIndex <= percent)
        {
            return true;
        }
        return false;
    }
}
