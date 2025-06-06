using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0953B
{
    public class R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            COD_AGENCIA_DEB,
            OPER_CONTA_DEB,
            NUM_CONTA_DEB,
            DIG_CONTA_DEB,
            COD_RETORNO_CEF
            INTO
            :MOVDEBCE-COD-AGENCIA-DEB:VIND-COD-AGENCIA-DEB,
            :MOVDEBCE-OPER-CONTA-DEB :VIND-OPER-CONTA-DEB,
            :MOVDEBCE-NUM-CONTA-DEB :VIND-NUM-CONTA-DEB,
            :MOVDEBCE-DIG-CONTA-DEB :VIND-DIG-CONTA-DEB,
            :MOVDEBCE-COD-RETORNO-CEF:VIND-COD-RETORNO-CEF
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_AGENCIA_DEB
							,
											OPER_CONTA_DEB
							,
											NUM_CONTA_DEB
							,
											DIG_CONTA_DEB
							,
											COD_RETORNO_CEF
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'";

            return query;
        }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string VIND_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string VIND_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string VIND_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string VIND_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string VIND_COD_RETORNO_CEF { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VIND_COD_AGENCIA_DEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_AGENCIA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_OPER_CONTA_DEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_OPER_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NUM_CONTA_DEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_DIG_CONTA_DEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DIG_CONTA_DEB) ? "-1" : "0";
            dta.MOVDEBCE_COD_RETORNO_CEF = result[i++].Value?.ToString();
            dta.VIND_COD_RETORNO_CEF = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_RETORNO_CEF) ? "-1" : "0";
            return dta;
        }

    }
}