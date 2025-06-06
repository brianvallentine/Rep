using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_RCAP ,
            COD_FONTE ,
            NUM_PROPOSTA ,
            DATA_CADASTRAMENTO ,
            DATA_MOVIMENTO ,
            VAL_RCAP_PRINCIPAL ,
            VALUE(NUM_TITULO,+0)
            INTO :RCAPS-NUM-RCAP ,
            :RCAPS-COD-FONTE ,
            :RCAPS-NUM-PROPOSTA ,
            :RCAPS-DATA-CADASTRAMENTO ,
            :RCAPS-DATA-MOVIMENTO ,
            :RCAPS-VAL-RCAP-PRINCIPAL ,
            :RCAPS-NUM-TITULO
            FROM SEGUROS.RCAPS
            WHERE NUM_RCAP = :PROPOSTA-NUM-RCAP
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_RCAP 
							,
											COD_FONTE 
							,
											NUM_PROPOSTA 
							,
											DATA_CADASTRAMENTO 
							,
											DATA_MOVIMENTO 
							,
											VAL_RCAP_PRINCIPAL 
							,
											VALUE(NUM_TITULO
							,+0)
											FROM SEGUROS.RCAPS
											WHERE NUM_RCAP = '{this.PROPOSTA_NUM_RCAP}'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_PROPOSTA { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPS_VAL_RCAP_PRINCIPAL { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string PROPOSTA_NUM_RCAP { get; set; }

        public static R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1 r2210_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r2210_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP_PRINCIPAL = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}