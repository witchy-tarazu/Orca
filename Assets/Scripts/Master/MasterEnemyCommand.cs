using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum CommandType
    {
        Card,
        Move,
        MoveNearestEnemy,
        Jump,
        JumpNearestEnemy,
    }

    public enum CommandTargetType
    {
        Self,
        Hero,
        Absolute,
    }

    [MemoryTable("enemy_command"), MessagePackObject(true)]
    public class MasterEnemyCommand
    {
        [PrimaryKey(0), SecondaryKey(0), NonUnique]
        public int PatternId { get; private set; }

        [PrimaryKey(1), NonUnique]
        public int Index { get; private set; }

        public CommandType Type { get; private set; }

        public CommandTargetType TargetType { get; private set; }

        public int Value { get; private set; }

        /// <summary>
        /// ���s�܂ł̑ҋ@����
        /// </summary>
        public int Wait { get; private set; }

        /// <summary>
        /// ��x�����������Ȃ�=���[�v���ɏ��O�����R�}���h���ǂ���
        /// </summary>
        public bool IsOnce { get; private set; }

        public MasterEnemyCommand(
            int patternId,
            int index,
            CommandType type,
            CommandTargetType targetType,
            int value,
            int wait,
            bool isOnce)
        {
            PatternId = patternId;
            Index = index;
            Type = type;
            TargetType = targetType;
            Value = value;
            Wait = wait;
            IsOnce = isOnce;
        }
    }
}