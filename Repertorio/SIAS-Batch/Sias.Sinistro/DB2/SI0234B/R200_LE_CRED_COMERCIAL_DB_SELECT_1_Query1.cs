using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0234B
{
    public class R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1 : QueryBasis<R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUREG,
            COD_AGENCIA,
            COD_OPERACAO,
            NUM_CONTRATO,
            CONTRATO_DIGITO,
            NUM_APOL_SINISTRO
            INTO :SINCREIN-COD-SUREG,
            :SINCREIN-COD-AGENCIA,
            :SINCREIN-COD-OPERACAO,
            :SINCREIN-NUM-CONTRATO,
            :SINCREIN-CONTRATO-DIGITO,
            :SINCREIN-NUM-APOL-SINISTRO
            FROM SEGUROS.SINISTRO_CRED_INT
            WHERE NUM_APOL_SINISTRO = :SINCREIN-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUREG
							,
											COD_AGENCIA
							,
											COD_OPERACAO
							,
											NUM_CONTRATO
							,
											CONTRATO_DIGITO
							,
											NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_CRED_INT
											WHERE NUM_APOL_SINISTRO = '{this.SINCREIN_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINCREIN_COD_SUREG { get; set; }
        public string SINCREIN_COD_AGENCIA { get; set; }
        public string SINCREIN_COD_OPERACAO { get; set; }
        public string SINCREIN_NUM_CONTRATO { get; set; }
        public string SINCREIN_CONTRATO_DIGITO { get; set; }
        public string SINCREIN_NUM_APOL_SINISTRO { get; set; }

        public static R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1 Execute(R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1 r200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1)
        {
            var ths = r200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_LE_CRED_COMERCIAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINCREIN_COD_SUREG = result[i++].Value?.ToString();
            dta.SINCREIN_COD_AGENCIA = result[i++].Value?.ToString();
            dta.SINCREIN_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINCREIN_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINCREIN_CONTRATO_DIGITO = result[i++].Value?.ToString();
            dta.SINCREIN_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}