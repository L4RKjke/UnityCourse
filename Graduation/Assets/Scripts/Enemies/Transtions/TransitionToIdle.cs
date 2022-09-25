public class TransitionToIdle : Transition
{
    private void Update()
    {
        if (Target == null)
        {
            NeedTransit = true;
        }
    }
}
