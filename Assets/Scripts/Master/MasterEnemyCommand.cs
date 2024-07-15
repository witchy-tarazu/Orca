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
        /// 実行までの待機時間
        /// </summary>
        public int Wait { get; }

        /// <summary>
        /// 一度しか発動しない=ループ時に除外されるコマンドかどうか
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