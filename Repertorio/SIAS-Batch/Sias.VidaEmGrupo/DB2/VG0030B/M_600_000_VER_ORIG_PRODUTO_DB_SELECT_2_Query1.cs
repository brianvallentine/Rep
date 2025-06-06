using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1 : QueryBasis<M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIG_PRODU
            INTO :WORIG-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :MNUM-APOLICE
            AND COD_SUBGRUPO = :WCOD-SUBGRUPO-EMP
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ORIG_PRODU
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.MNUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.WCOD_SUBGRUPO_EMP}'
											WITH UR";

            return query;
        }
        public string WORIG_PRODUTO { get; set; }
        public string WCOD_SUBGRUPO_EMP { get; set; }
        public string MNUM_APOLICE { get; set; }

        public static M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1 Execute(M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1 m_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1)
        {
            var ths = m_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1();
            var i = 0;
            dta.WORIG_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}