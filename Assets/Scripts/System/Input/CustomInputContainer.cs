namespace Orca
{
    public enum CustomCommand
    {
        None,
        Select,
        Cancel,
        Merge,
        Decide,
    }

    public class CustomInputContainer
    {
        public CustomCommand CustomCommand { get; set; }
        public DirectionCommand DirectionCommand { get; set; }

        public CustomInputContainer()
        {
            Reset();
        }

        public void Reset()
        {
            CustomCommand = CustomCommand.None;
            DirectionCommand = DirectionCommand.None;
        }
    }
}