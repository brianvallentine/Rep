using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO_COBRANCA
            ,DATA_VENCIMENTO
            ,DATA_ENVIO
            INTO :MOVDEBCE-SITUACAO-COBRANCA
            ,:MOVDEBCE-DATA-VENCIMENTO
            ,:MOVDEBCE-DATA-ENVIO:VIND-NULL01
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :BILHETE-NUM-BILHETE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO_COBRANCA
											,DATA_VENCIMENTO
											,DATA_ENVIO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.BILHETE_NUM_BILHETE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0240_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_ENVIO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DATA_ENVIO) ? "-1" : "0";
            return dta;
        }

    }
}