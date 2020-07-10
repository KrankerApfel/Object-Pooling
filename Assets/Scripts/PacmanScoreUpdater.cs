public class PacmanScoreUpdater : IUpdater
{
    public float pacSpeed = 6.0f;

    private TAccessor<PacmanList> _pacmans;

    public void SystemUpdate()
    {
        foreach (var module in _pacmans.GetAllModules())
        {
            module.navMeshAgent.speed = pacSpeed;
        }
    }

    public void InitAccessors()
    {
        _pacmans = TAccessor<PacmanList>.Instance;
    }
}
