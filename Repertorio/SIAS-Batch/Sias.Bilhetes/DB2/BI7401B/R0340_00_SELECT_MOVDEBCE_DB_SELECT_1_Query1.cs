using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,SITUACAO_COBRANCA
            INTO :MOVDEBCE-NUM-APOLICE
            ,:MOVDEBCE-NUM-ENDOSSO
            ,:MOVDEBCE-NUM-PARCELA
            ,:MOVDEBCE-SITUACAO-COBRANCA
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND SITUACAO_COBRANCA = '8'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ENDOSSO
											,NUM_PARCELA
											,SITUACAO_COBRANCA
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND SITUACAO_COBRANCA = '8'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}