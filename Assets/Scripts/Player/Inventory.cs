using System.Collections.Generic;
using System.Linq;

namespace Orca
{
    public class Inventory
    {
        private HashSet<LegacyInfo> LegacyInfos { get; set; } = new();
        private HashSet<PieceInfo> PieceInfos { get; set; } = new();

        public void Reset()
        {
            LegacyInfos.Clear();
            PieceInfos.Clear();
        }

        public void AddPiece(MasterPieceRelation piece, int stock)
        {
            var info = PieceInfos.FirstOrDefault(x => x.Master == piece);
            if (info == null)
            {
                PieceInfos.Add(new(piece, stock));
                return;
            }

            info.AddStock(stock);
        }

        public void RemovePiece(MasterPieceRelation piece, int stock)
        {
            var info = PieceInfos.FirstOrDefault(x => x.Master == piece);
            info.RemoveStock(stock);

            if (info.Stock <= 0)
            {
                PieceInfos.Remove(info);
            }
        }

        public void AddLegacy(MasterLegacy legacy)
        {
            LegacyInfos.Add(new(legacy, 0));
        }

        public List<MasterPieceRelation> GetPieceList()
        {
            List<MasterPieceRelation> list = new();
            foreach (var info in PieceInfos.OrderBy(x => x.Master.PieceId))
            {
                for (int i = 0; i < info.Stock; i++)
                {
                    list.Add(info.Master);
                }
            }

            return list;
        }

        public List<MasterLegacy> GetBattleLegacyList()
        {
            List<MasterLegacy> list = new();
            return list;
        }

        public List<MasterLegacy> GetCustomLegacyList()
        {
            List<MasterLegacy> list = new();
            return list;
        }

        public List<MasterLegacy> GetMapLegacyList()
        {
            List<MasterLegacy> list = new();
            return list;
        }
    }
}