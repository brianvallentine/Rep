using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP01B
{
    public class R2040_PEGA_SERVICO_DB_SELECT_1_Query1 : QueryBasis<R2040_PEGA_SERVICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CEP,
            COD_SERVICO_ISS
            INTO :FORNECED-CEP,
            :FORNECED-COD-SERVICO-ISS
            FROM
            SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.FORNECEDORES F
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CEP
							,
											COD_SERVICO_ISS
											FROM
											SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.FORNECEDORES F
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO";

            return query;
        }
        public string FORNECED_CEP { get; set; }
        public string FORNECED_COD_SERVICO_ISS { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R2040_PEGA_SERVICO_DB_SELECT_1_Query1 Execute(R2040_PEGA_SERVICO_DB_SELECT_1_Query1 r2040_PEGA_SERVICO_DB_SELECT_1_Query1)
        {
            var ths = r2040_PEGA_SERVICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2040_PEGA_SERVICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2040_PEGA_SERVICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FORNECED_CEP = result[i++].Value?.ToString();
            dta.FORNECED_COD_SERVICO_ISS = result[i++].Value?.ToString();
            return dta;
        }

    }
}