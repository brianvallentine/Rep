using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1 : QueryBasis<R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_OCORRENCIA
            INTO :SINISMES-DATA-OCORRENCIA
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO
            ORDER BY DATA_OCORRENCIA DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_OCORRENCIA
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_CERTIFICADO = '{this.SINISMES_NUM_CERTIFICADO}'
											ORDER BY DATA_OCORRENCIA DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }

        public static R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1 Execute(R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1 r0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1)
        {
            var ths = r0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0518_00_ACESSA_DT_OCORRENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}