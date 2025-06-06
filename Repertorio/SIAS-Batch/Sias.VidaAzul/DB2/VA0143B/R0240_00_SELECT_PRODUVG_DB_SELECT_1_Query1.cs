using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0143B
{
    public class R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIG_PRODU
            INTO :PRODUVG-ORIG-PRODU
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE
            AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO
            AND ORIG_PRODU = 'ESPEC'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIG_PRODU
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.HISCONPA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.HISCONPA_COD_SUBGRUPO}'
											AND ORIG_PRODU = 'ESPEC'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }

        public static R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0240_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}