using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerAnimator))]
public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private List<Point> SpawnPoints;
    [SerializeField] private Resource PrefabResource;

    [SerializeField] protected SpawnerSettings SpawnerSettings;

    private Stack<Resource> Resources;
    private SpawnerAnimator SpawnerAnimator;
    private bool IsEmpty;
    private float SpawnTimer = 0f;

    protected int CountPerHit;
    protected int CountResources;
    protected float DelayBeforeRecovery;

    public float ProductionRate { get; protected set; }
    public int CurrentCountResource => Resources.Count;

    private void Awake()
    {
        Resources = new Stack<Resource>();
        SpawnerAnimator = GetComponent<SpawnerAnimator>();
    }

    private void Update()
    {
        SpawnTimer += Time.deltaTime;

        if (IsEmpty == true && SpawnTimer >= DelayBeforeRecovery)
        {
            InstantiateResources();
            SpawnerAnimator.PlayAnimationIncrease();
        }
    }

    private void ThrowResource()
    {
        SpawnerAnimator.PlayVibrationAnimation();

        int index = Random.Range(0, SpawnPoints.Count);

        Resource resource = Resources.Pop();

        resource.transform.DOJump(SpawnPoints[index].transform.position, resource.JumpPower, resource.NumJumps, resource.Duration)
            .SetUpdate(UpdateType.Normal, false)
            .SetLink(resource.gameObject)
            .OnKill(() =>
            {
                resource.ChangeLayer();
                resource.EnableTimer();
            });

        if (Resources.Count == 0)
            ResetTimerSpawn();
    }

    private void ResetTimerSpawn()
    {
        SpawnerAnimator.PlayAnimationDecrease();
        SpawnTimer = 0f;
        IsEmpty = true;
    }

    protected void InstantiateResources()
    {
        for (int i = 0; i < CountResources; i++)
            Resources.Push(Instantiate(PrefabResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));

        IsEmpty = false;
    }

    public void ThrowAwayResources()
    {
        if (Resources.Count >= CountPerHit)
            for (int i = 0; i < CountPerHit; i++)
                ThrowResource();
        else
            for (int i = 0; i <= Resources.Count; i++)
                ThrowResource();
    }
}
