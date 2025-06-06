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
    public class R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            OPCAO_PAGAMENTO ,
            PERI_PAGAMENTO ,
            DIA_DEBITO ,
            COD_AGENCIA_DEBITO ,
            OPE_CONTA_DEBITO ,
            NUM_CONTA_DEBITO ,
            DIG_CONTA_DEBITO ,
            NUM_CARTAO_CREDITO
            INTO
            :OPCPAGVI-OPCAO-PAGAMENTO ,
            :OPCPAGVI-PERI-PAGAMENTO ,
            :OPCPAGVI-DIA-DEBITO ,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGENCIA ,
            :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPERACAO ,
            :OPCPAGVI-NUM-CONTA-DEBITO :VIND-CONTA ,
            :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIG-CONTA ,
            :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OPCAO_PAGAMENTO 
							,
											PERI_PAGAMENTO 
							,
											DIA_DEBITO 
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
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPERACAO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_CONTA { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIG_CONTA { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_CARTAO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 r1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGENCIA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPERACAO = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_CONTA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIG_CONTA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_CARTAO = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}