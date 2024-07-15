using MasterMemory;
using MessagePack;

namespace Orca
{
    public enum CommandType
    {
        Attack,
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
        [PrimaryKey(0)]
        [SecondaryKey(0), NonUnique]
        public int PatternId { get; }

        [PrimaryKey(1)]
        public int Index { get; }

        public CommandType Type { get; }

        public CommandTargetType TargetType { get; }

        public int Value { get; }

        /// <summary>
        /// ���s�܂ł̑ҋ@����
        /// </summary>
        public int Wait { get; }

        /// <summary>
        /// ��x�����������Ȃ�=���[�v���ɏ��O�����R�}���h���ǂ���
        /// </summary>
        public bool IsOnce { get; }

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