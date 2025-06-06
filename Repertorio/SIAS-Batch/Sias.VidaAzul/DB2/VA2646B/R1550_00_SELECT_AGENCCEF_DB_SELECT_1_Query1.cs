using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 : QueryBasis<R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            SITUACAO
            INTO :AGENCCEF-COD-AGENCIA,
            :AGENCCEF-SITUACAO
            FROM SEGUROS.AGENCIAS_CEF
            WHERE COD_AGENCIA = :ENDOSSOS-AGE-RCAP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											SITUACAO
											FROM SEGUROS.AGENCIAS_CEF
											WHERE COD_AGENCIA = '{this.ENDOSSOS_AGE_RCAP}'";

            return query;
        }
        public string AGENCCEF_COD_AGENCIA { get; set; }
        public string AGENCCEF_SITUACAO { get; set; }
        public string ENDOSSOS_AGE_RCAP { get; set; }

        public static R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 Execute(R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 r1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1)
        {
            var ths = r1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1550_00_SELECT_AGENCCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCCEF_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}