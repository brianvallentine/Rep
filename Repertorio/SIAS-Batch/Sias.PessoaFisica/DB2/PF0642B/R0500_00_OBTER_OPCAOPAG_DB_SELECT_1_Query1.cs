using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 : QueryBasis<R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1>
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
            DIG_CONTA_DEBITO
            INTO
            :OPCPAGVI-OPCAO-PAGAMENTO ,
            :OPCPAGVI-PERI-PAGAMENTO ,
            :OPCPAGVI-DIA-DEBITO ,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB,
            :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB ,
            :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB ,
            :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE (NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO
            OR NUM_CERTIFICADO = :WHOST-NUM-TERMO)
            AND DATA_TERVIGENCIA = :OPCPAGVI-DATA-TERVIGENCIA
            WITH UR
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
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE (NUM_CERTIFICADO = '{this.OPCPAGVI_NUM_CERTIFICADO}'
											OR NUM_CERTIFICADO = '{this.WHOST_NUM_TERMO}')
											AND DATA_TERVIGENCIA = '{this.OPCPAGVI_DATA_TERVIGENCIA}'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string OPCPAGVI_DATA_TERVIGENCIA { get; set; }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }
        public string WHOST_NUM_TERMO { get; set; }

        public static R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 Execute(R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
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