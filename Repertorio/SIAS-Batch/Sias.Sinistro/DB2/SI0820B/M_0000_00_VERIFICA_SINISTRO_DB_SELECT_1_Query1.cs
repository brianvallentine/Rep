using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO
            INTO :V0SINCRED-NUM-APOL-SINISTRO
            FROM SEGUROS.V0SINCREDINT
            WHERE COD_SUREG = :V0CRED-COD-SUREG
            AND COD_AGENCIA = :V0CRED-COD-AGENCIA
            AND CODOPER = :V0CRED-CODOPER
            AND NUM_CONTRATO = :V0CRED-NUM-CONTRATO
            AND CONTRATO_DIGITO = :V0CRED-CONTRATO-DIGITO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
											FROM SEGUROS.V0SINCREDINT
											WHERE COD_SUREG = '{this.V0CRED_COD_SUREG}'
											AND COD_AGENCIA = '{this.V0CRED_COD_AGENCIA}'
											AND CODOPER = '{this.V0CRED_CODOPER}'
											AND NUM_CONTRATO = '{this.V0CRED_NUM_CONTRATO}'
											AND CONTRATO_DIGITO = '{this.V0CRED_CONTRATO_DIGITO}'";

            return query;
        }
        public string V0SINCRED_NUM_APOL_SINISTRO { get; set; }
        public string V0CRED_CONTRATO_DIGITO { get; set; }
        public string V0CRED_NUM_CONTRATO { get; set; }
        public string V0CRED_COD_AGENCIA { get; set; }
        public string V0CRED_COD_SUREG { get; set; }
        public string V0CRED_CODOPER { get; set; }

        public static M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1 Execute(M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1 m_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SINCRED_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}