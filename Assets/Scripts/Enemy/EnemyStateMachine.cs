public class EnemyStateMachine : GenericStateMachine<EnemyController>
{
    public EnemyStateMachine(EnemyController owner) : base(owner)
    {
        this.owner = owner;

        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {

    }
}
