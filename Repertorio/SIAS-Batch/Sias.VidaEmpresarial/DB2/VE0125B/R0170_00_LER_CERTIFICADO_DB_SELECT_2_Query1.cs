using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0125B
{
    public class R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1 : QueryBasis<R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            , COD_PRODUTO
            , SIT_REGISTRO
            , FAIXA_RENDA_IND
            , FAIXA_RENDA_FAM
            , STA_ANTECIPACAO
            , STA_MUDANCA_PLANO
            INTO :PROPOVA-NUM-CERTIFICADO
            ,:PROPOVA-COD-PRODUTO
            ,:PROPOVA-SIT-REGISTRO
            ,:PROPOVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND
            ,:PROPOVA-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM
            ,:PROPOVA-STA-ANTECIPACAO:VIND-STA-ANTECIPACAO
            ,:PROPOVA-STA-MUDANCA-PLANO:VIND-STA-MUDANCA
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											, COD_PRODUTO
											, SIT_REGISTRO
											, FAIXA_RENDA_IND
											, FAIXA_RENDA_FAM
											, STA_ANTECIPACAO
											, STA_MUDANCA_PLANO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string PROPOVA_FAIXA_RENDA_FAM { get; set; }
        public string VIND_FAIXA_RENDA_FAM { get; set; }
        public string PROPOVA_STA_ANTECIPACAO { get; set; }
        public string VIND_STA_ANTECIPACAO { get; set; }
        public string PROPOVA_STA_MUDANCA_PLANO { get; set; }
        public string VIND_STA_MUDANCA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1 Execute(R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1 r0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1)
        {
            var ths = r0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_FAM) ? "-1" : "0";
            dta.PROPOVA_STA_ANTECIPACAO = result[i++].Value?.ToString();
            dta.VIND_STA_ANTECIPACAO = string.IsNullOrWhiteSpace(dta.PROPOVA_STA_ANTECIPACAO) ? "-1" : "0";
            dta.PROPOVA_STA_MUDANCA_PLANO = result[i++].Value?.ToString();
            dta.VIND_STA_MUDANCA = string.IsNullOrWhiteSpace(dta.PROPOVA_STA_MUDANCA_PLANO) ? "-1" : "0";
            return dta;
        }

    }
}