using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 : QueryBasis<R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMCDT,
            COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA
            INTO :V0CEDE-NOMECED,
            :V0CEDE-AGENCIA,
            :V0CEDE-OPERACAO,
            :V0CEDE-CONTA,
            :V0CEDE-DIGCC
            FROM SEGUROS.V0CEDENTE
            WHERE CODCDT = :V0PROD-CODCDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMCDT
							,
											COD_AGENCIA
							,
											OPERACAO_CONTA
							,
											NUM_CONTA
							,
											DIG_CONTA
											FROM SEGUROS.V0CEDENTE
											WHERE CODCDT = '{this.V0PROD_CODCDT}'";

            return query;
        }
        public string V0CEDE_NOMECED { get; set; }
        public string V0CEDE_AGENCIA { get; set; }
        public string V0CEDE_OPERACAO { get; set; }
        public string V0CEDE_CONTA { get; set; }
        public string V0CEDE_DIGCC { get; set; }
        public string V0PROD_CODCDT { get; set; }

        public static R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 Execute(R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 r2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1)
        {
            var ths = r2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CEDE_NOMECED = result[i++].Value?.ToString();
            dta.V0CEDE_AGENCIA = result[i++].Value?.ToString();
            dta.V0CEDE_OPERACAO = result[i++].Value?.ToString();
            dta.V0CEDE_CONTA = result[i++].Value?.ToString();
            dta.V0CEDE_DIGCC = result[i++].Value?.ToString();
            return dta;
        }

    }
}