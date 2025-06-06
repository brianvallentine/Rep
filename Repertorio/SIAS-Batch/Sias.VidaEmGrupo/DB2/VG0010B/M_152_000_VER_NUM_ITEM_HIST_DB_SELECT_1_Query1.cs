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
    public class M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1 : QueryBasis<M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_ITEM), 0)
            INTO :SNUM-ITEM-HIST
            FROM SEGUROS.V0HISTSEGVG
            WHERE NUM_APOLICE = :MNUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_ITEM)
							, 0)
											FROM SEGUROS.V0HISTSEGVG
											WHERE NUM_APOLICE = '{this.MNUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string SNUM_ITEM_HIST { get; set; }
        public string MNUM_APOLICE { get; set; }

        public static M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1 Execute(M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1 m_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1)
        {
            var ths = m_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.SNUM_ITEM_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}