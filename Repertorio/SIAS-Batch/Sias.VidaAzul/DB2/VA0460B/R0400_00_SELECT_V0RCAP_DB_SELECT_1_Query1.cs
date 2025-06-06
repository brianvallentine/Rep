using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1 : QueryBasis<R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE ,
            NUM_RCAP ,
            VAL_RCAP ,
            VAL_RCAP_PRINCIPAL ,
            SIT_REGISTRO ,
            COD_OPERACAO ,
            CODIGO_PRODUTO ,
            AGE_COBRANCA
            INTO :RCAPS-COD-FONTE ,
            :RCAPS-NUM-RCAP ,
            :RCAPS-VAL-RCAP ,
            :RCAPS-VAL-RCAP-PRINCIPAL,
            :RCAPS-SIT-REGISTRO ,
            :RCAPS-COD-OPERACAO ,
            :RCAPS-CODIGO-PRODUTO:VIND-CODPRODU ,
            :RCAPS-AGE-COBRANCA:VIND-AGECOBR
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO = :RCAPS-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE 
							,
											NUM_RCAP 
							,
											VAL_RCAP 
							,
											VAL_RCAP_PRINCIPAL 
							,
											SIT_REGISTRO 
							,
											COD_OPERACAO 
							,
											CODIGO_PRODUTO 
							,
											AGE_COBRANCA
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO = '{this.RCAPS_NUM_TITULO}'";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_VAL_RCAP_PRINCIPAL { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_CODIGO_PRODUTO { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string VIND_AGECOBR { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

        public static R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1 Execute(R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1 r0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP_PRINCIPAL = result[i++].Value?.ToString();
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RCAPS_CODIGO_PRODUTO = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.RCAPS_CODIGO_PRODUTO) ? "-1" : "0";
            dta.RCAPS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.VIND_AGECOBR = string.IsNullOrWhiteSpace(dta.RCAPS_AGE_COBRANCA) ? "-1" : "0";
            return dta;
        }

    }
}