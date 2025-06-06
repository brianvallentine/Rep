using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0140_SELECT_OPCAO_DB_SELECT_1_Query1 : QueryBasis<M_0140_SELECT_OPCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO,
            COD_AGENCIA_DEBITO,
            OPE_CONTA_DEBITO,
            NUM_CONTA_DEBITO,
            DIG_CONTA_DEBITO,
            NUM_CARTAO_CREDITO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-COD-AGE-DEB,
            :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE-CONTA-DEB,
            :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUM-CONTA-DEB,
            :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG-CONTA-DEB,
            :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUM-CARTAO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
							,
											COD_AGENCIA_DEBITO
							,
											OPE_CONTA_DEBITO
							,
											NUM_CONTA_DEBITO
							,
											DIG_CONTA_DEBITO
							,
											NUM_CARTAO_CREDITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.HISCOBPR_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_COD_AGE_DEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPE_CONTA_DEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_NUM_CONTA_DEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIG_CONTA_DEB { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_NUM_CARTAO { get; set; }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }

        public static M_0140_SELECT_OPCAO_DB_SELECT_1_Query1 Execute(M_0140_SELECT_OPCAO_DB_SELECT_1_Query1 m_0140_SELECT_OPCAO_DB_SELECT_1_Query1)
        {
            var ths = m_0140_SELECT_OPCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0140_SELECT_OPCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0140_SELECT_OPCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_COD_AGE_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPE_CONTA_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_NUM_CONTA_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIG_CONTA_DEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_NUM_CARTAO = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}