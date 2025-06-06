using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMPS
{
    public class R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 : QueryBasis<R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_CARTACO), 0)
            INTO :GECARACO-NUM-OCORR-CARTACO
            FROM SEGUROS.GE_CARTA_ACOMP
            WHERE NUM_CARTA = :GECARACO-NUM-CARTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_CARTACO)
							, 0)
											FROM SEGUROS.GE_CARTA_ACOMP
											WHERE NUM_CARTA = '{this.GECARACO_NUM_CARTA}'";

            return query;
        }
        public string GECARACO_NUM_OCORR_CARTACO { get; set; }
        public string GECARACO_NUM_CARTA { get; set; }

        public static R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 Execute(R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECARACO_NUM_OCORR_CARTACO = result[i++].Value?.ToString();
            return dta;
        }

    }
}