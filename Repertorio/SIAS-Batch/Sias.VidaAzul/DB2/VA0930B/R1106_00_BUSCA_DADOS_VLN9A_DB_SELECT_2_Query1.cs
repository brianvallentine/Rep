using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1 : QueryBasis<R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO
            , DIA_DEBITO
            , COD_AGENCIA_DEBITO
            , OPE_CONTA_DEBITO
            , NUM_CONTA_DEBITO
            , DIG_CONTA_DEBITO
            , NUM_CARTAO_CREDITO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO
            , :OPCPAGVI-DIA-DEBITO
            , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-COD-AGE-DEB
            , :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE-CTA-DEB
            , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUM-CTA-DEB
            , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG-CTA-DEB
            , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUM-CAR-CRE
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
											, DIA_DEBITO
											, COD_AGENCIA_DEBITO
											, OPE_CONTA_DEBITO
											, NUM_CONTA_DEBITO
											, DIG_CONTA_DEBITO
											, NUM_CARTAO_CREDITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_COD_AGE_DEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPE_CTA_DEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_NUM_CTA_DEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIG_CTA_DEB { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_NUM_CAR_CRE { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1 Execute(R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1 r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1)
        {
            var ths = r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_COD_AGE_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPE_CTA_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_NUM_CTA_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIG_CTA_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_NUM_CAR_CRE = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}