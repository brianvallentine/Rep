using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO,
            DIA_DEBITO,
            COD_AGENCIA_DEBITO,
            OPE_CONTA_DEBITO,
            NUM_CONTA_DEBITO,
            DIG_CONTA_DEBITO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO,
            :OPCPAGVI-DIA-DEBITO,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB,
            :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB,
            :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB,
            :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
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
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO =
											'{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 r1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGECTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPRCTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_NUMCTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIGCTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            return dta;
        }

    }
}