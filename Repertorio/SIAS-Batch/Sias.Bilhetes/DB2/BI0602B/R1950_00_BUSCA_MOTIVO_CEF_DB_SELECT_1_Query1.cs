using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0602B
{
    public class R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1 : QueryBasis<R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RETORNO_CEF,
            DATA_VENCIMENTO ,
            DATA_MOVIMENTO ,
            TIMESTAMP
            INTO :WS-SITUAC-CEF:WIND-NULL ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-DATA-MOVIMENTO ,
            :MOVDEBCE-TIMESTAMP
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_RETORNO_CEF
							,
											DATA_VENCIMENTO 
							,
											DATA_MOVIMENTO 
							,
											TIMESTAMP
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'";

            return query;
        }
        public string WS_SITUAC_CEF { get; set; }
        public string WIND_NULL { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_TIMESTAMP { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1 Execute(R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1 r1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1)
        {
            var ths = r1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_SITUAC_CEF = result[i++].Value?.ToString();
            dta.WIND_NULL = string.IsNullOrWhiteSpace(dta.WS_SITUAC_CEF) ? "-1" : "0";
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}