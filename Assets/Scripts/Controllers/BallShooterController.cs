using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Cysharp.Threading.Tasks;

public class BallShooterController : MonoBehaviour
{
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private UIController _healthController;

    private Random _random = new Random();

    const float TIME = 0.5f;

    public async UniTask ShootBomb(float delayTimeInSeconds = 0)
    {
        var target = GetTarget();
        await StartTargetAnimation(delayTimeInSeconds, target);
        Shoot(target, _bombPrefab);

    }

    public async UniTask ShootMoney(float delayTimeInSeconds = 0)
    {
        var target = GetTarget();
        await StartTargetAnimation(delayTimeInSeconds, target);
        Shoot(target, _moneyPrefab);
    }

    public async UniTask ShootBall(float delayTimeInSeconds = 0)
    {
        var target = GetTarget();
        await StartTargetAnimation(delayTimeInSeconds, target);
        Shoot(target, _ballPrefab);
    }

    private Transform GetTarget()
    {
        var index = _random.Next(_targets.Count);
        var target = _targets[index];
        return target;
    }

    private async UniTask StartTargetAnimation(float animationTime, Transform target)
    {
        target.gameObject.SetActive(true);
        await UniTask.Delay((int)(animationTime * 1000));
        target.gameObject.SetActive(false);
    }

    private void Shoot(Transform target, GameObject ballPrefab)
    {
        var prefab = Instantiate(ballPrefab, _shootPosition.position, Quaternion.identity, transform);
        var speed = target.position - prefab.transform.position - Physics.gravity * TIME * TIME / 2 / TIME;
        prefab.GetComponent<Rigidbody>().AddForce(speed, ForceMode.Impulse);
    }
}
