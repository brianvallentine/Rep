using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1 : QueryBasis<M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_ITEM), 0)
            INTO :SNUM-ITEM-SEGUR
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_APOLICE = :MNUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_ITEM)
							, 0)
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_APOLICE = '{this.MNUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string SNUM_ITEM_SEGUR { get; set; }
        public string MNUM_APOLICE { get; set; }

        public static M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1 Execute(M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1 m_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1)
        {
            var ths = m_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SNUM_ITEM_SEGUR = result[i++].Value?.ToString();
            return dta;
        }

    }
}