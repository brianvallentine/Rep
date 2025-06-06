using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :PROPOVA-COD-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE
            AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.PRODUVG_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PRODUVG_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_NUM_APOLICE { get; set; }

        public static R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}