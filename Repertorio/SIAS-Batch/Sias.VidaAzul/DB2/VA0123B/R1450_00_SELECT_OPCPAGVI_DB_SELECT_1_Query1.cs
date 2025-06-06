using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 : QueryBasis<R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            OPCAO_PAGAMENTO
            ,VALUE(COD_AGENCIA_DEBITO,0)
            ,VALUE(OPE_CONTA_DEBITO,0)
            ,VALUE(NUM_CONTA_DEBITO,0)
            ,VALUE(DIG_CONTA_DEBITO,0)
            ,NUM_CARTAO_CREDITO
            ,PERI_PAGAMENTO
            INTO
            :OPCPAGVI-OPCAO-PAGAMENTO,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGEDEB,
            :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB,
            :OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB,
            :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB,
            :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUMCAR,
            :OPCPAGVI-PERI-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											OPCAO_PAGAMENTO
											,VALUE(COD_AGENCIA_DEBITO
							,0)
											,VALUE(OPE_CONTA_DEBITO
							,0)
											,VALUE(NUM_CONTA_DEBITO
							,0)
											,VALUE(DIG_CONTA_DEBITO
							,0)
											,NUM_CARTAO_CREDITO
											,PERI_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGEDEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPEDEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_CTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGDEB { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_NUMCAR { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 Execute(R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 r1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1)
        {
            var ths = r1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGEDEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPEDEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_CTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIGDEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_NUMCAR = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}