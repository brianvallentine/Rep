using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 : QueryBasis<R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO,
            COD_AGENCIA_DEBITO,
            OPE_CONTA_DEBITO,
            NUM_CONTA_DEBITO,
            DIG_CONTA_DEBITO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGE,
            :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE,
            :OPCPAGVI-NUM-CONTA-DEBITO:VIND-CTA,
            :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
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
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGE { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPE { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_CTA { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIG { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 Execute(R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 r1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1)
        {
            var ths = r1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGE = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPE = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_CTA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIG = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            return dta;
        }

    }
}