using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1 : QueryBasis<R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CERTIFICADO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            OPCAO_PAGAMENTO ,
            PERI_PAGAMENTO ,
            DIA_DEBITO ,
            COD_AGENCIA_DEBITO ,
            OPE_CONTA_DEBITO ,
            NUM_CONTA_DEBITO ,
            DIG_CONTA_DEBITO
            INTO
            :OPPAGVA-NUM-CERTIFICADO ,
            :OPPAGVA-DATA-INIVIGENCIA ,
            :OPPAGVA-DATA-TERVIGENCIA ,
            :OPPAGVA-OPCAO-PAGAMENTO ,
            :OPPAGVA-PERI-PAGAMENTO ,
            :OPPAGVA-DIA-DEBITO ,
            :OPPAGVA-COD-AGENCIA-DEBITO:VIND-AGEDEB,
            :OPPAGVA-OPE-CONTA-DEBITO:VIND-OPRCTADEB,
            :OPPAGVA-NUM-CONTA-DEBITO:VIND-NUMCTADEB,
            :OPPAGVA-DIG-CONTA-DEBITO:VIND-DIGCTADEB
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :OPPAGVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA IN (:HOST-DT-TERVIG1,
            :HOST-DT-TERVIG2)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CERTIFICADO 
							,
											DATA_INIVIGENCIA 
							,
											DATA_TERVIGENCIA 
							,
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
											WHERE NUM_CERTIFICADO =
											'{this.OPPAGVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA IN ('{this.HOST_DT_TERVIG1}'
							,
											'{this.HOST_DT_TERVIG2}')
											WITH UR";

            return query;
        }
        public string OPPAGVA_NUM_CERTIFICADO { get; set; }
        public string OPPAGVA_DATA_INIVIGENCIA { get; set; }
        public string OPPAGVA_DATA_TERVIGENCIA { get; set; }
        public string OPPAGVA_OPCAO_PAGAMENTO { get; set; }
        public string OPPAGVA_PERI_PAGAMENTO { get; set; }
        public string OPPAGVA_DIA_DEBITO { get; set; }
        public string OPPAGVA_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGEDEB { get; set; }
        public string OPPAGVA_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string OPPAGVA_NUM_CONTA_DEBITO { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string OPPAGVA_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string HOST_DT_TERVIG1 { get; set; }
        public string HOST_DT_TERVIG2 { get; set; }

        public static R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1 Execute(R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1 r0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1)
        {
            var ths = r0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPPAGVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.OPPAGVA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.OPPAGVA_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.OPPAGVA_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPPAGVA_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPPAGVA_DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPPAGVA_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGEDEB = string.IsNullOrWhiteSpace(dta.OPPAGVA_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPPAGVA_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPRCTADEB = string.IsNullOrWhiteSpace(dta.OPPAGVA_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPPAGVA_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_NUMCTADEB = string.IsNullOrWhiteSpace(dta.OPPAGVA_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPPAGVA_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIGCTADEB = string.IsNullOrWhiteSpace(dta.OPPAGVA_DIG_CONTA_DEBITO) ? "-1" : "0";
            return dta;
        }

    }
}