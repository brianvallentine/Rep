using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO ,
            VALOR_DEBITO ,
            DIA_DEBITO ,
            COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            NUM_CARTAO
            INTO :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-VALOR-DEBITO ,
            :MOVDEBCE-DIA-DEBITO ,
            :MOVDEBCE-COD-AGENCIA-DEB:VIND-AGECTADEB,
            :MOVDEBCE-OPER-CONTA-DEB:VIND-OPRCTADEB ,
            :MOVDEBCE-NUM-CONTA-DEB:VIND-NUMCTADEB ,
            :MOVDEBCE-DIG-CONTA-DEB:VIND-DIGCTADEB ,
            :MOVDEBCE-NUM-CARTAO:VIND-CARTAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND NUM_ENDOSSO = :RELATORI-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO 
							,
											VALOR_DEBITO 
							,
											DIA_DEBITO 
							,
											COD_AGENCIA_DEB 
							,
											OPER_CONTA_DEB 
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB 
							,
											NUM_CARTAO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.RELATORI_NUM_ENDOSSO}'";

            return query;
        }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_DIA_DEBITO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_CARTAO { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIA_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VIND_AGECTADEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_AGENCIA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_OPRCTADEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_OPER_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NUMCTADEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_DIGCTADEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DIG_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_CARTAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CARTAO) ? "-1" : "0";
            return dta;
        }

    }
}