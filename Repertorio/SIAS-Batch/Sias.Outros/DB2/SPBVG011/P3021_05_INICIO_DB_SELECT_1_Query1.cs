using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG011
{
    public class P3021_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P3021_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MOEDA
            INTO :VG077-COD-MOEDA
            FROM SEGUROS.VG_INDICES
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO
            AND DTH_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_MOEDA
											FROM SEGUROS.VG_INDICES
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.RELATORI_COD_SUBGRUPO}'
											AND DTH_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string VG077_COD_MOEDA { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static P3021_05_INICIO_DB_SELECT_1_Query1 Execute(P3021_05_INICIO_DB_SELECT_1_Query1 p3021_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p3021_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P3021_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P3021_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG077_COD_MOEDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}