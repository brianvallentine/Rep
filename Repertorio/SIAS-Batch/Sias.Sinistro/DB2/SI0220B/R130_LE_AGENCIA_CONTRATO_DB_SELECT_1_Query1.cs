using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0220B
{
    public class R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1 : QueryBasis<R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            NOME_AGENCIA
            INTO :AGENCCEF-COD-AGENCIA,
            :AGENCCEF-NOME-AGENCIA
            FROM SEGUROS.AGENCIAS_CEF
            WHERE COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											NOME_AGENCIA
											FROM SEGUROS.AGENCIAS_CEF
											WHERE COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'
											WITH UR";

            return query;
        }
        public string AGENCCEF_COD_AGENCIA { get; set; }
        public string AGENCCEF_NOME_AGENCIA { get; set; }

        public static R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1 Execute(R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1 r130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1)
        {
            var ths = r130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_LE_AGENCIA_CONTRATO_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCCEF_NOME_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}