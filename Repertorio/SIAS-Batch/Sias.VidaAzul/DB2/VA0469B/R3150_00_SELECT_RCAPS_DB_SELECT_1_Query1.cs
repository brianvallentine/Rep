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
    public class R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            ,NUM_RCAP
            ,VAL_RCAP
            ,VAL_RCAP_PRINCIPAL
            ,DATA_CADASTRAMENTO
            ,DATA_MOVIMENTO
            ,NUM_TITULO
            ,NUM_CERTIFICADO
            INTO :RCAPS-COD-FONTE
            ,:RCAPS-NUM-RCAP
            ,:RCAPS-VAL-RCAP
            ,:RCAPS-VAL-RCAP-PRINCIPAL
            ,:RCAPS-DATA-CADASTRAMENTO
            ,:RCAPS-DATA-MOVIMENTO
            ,:RCAPS-NUM-TITULO:VIND-NULL01
            ,:RCAPS-NUM-CERTIFICADO:VIND-NULL02
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND SIT_REGISTRO = '0'
            AND COD_OPERACAO IN (100,110)
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											,NUM_RCAP
											,VAL_RCAP
											,VAL_RCAP_PRINCIPAL
											,DATA_CADASTRAMENTO
											,DATA_MOVIMENTO
											,NUM_TITULO
											,NUM_CERTIFICADO
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND SIT_REGISTRO = '0'
											AND COD_OPERACAO IN (100
							,110)
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_VAL_RCAP_PRINCIPAL { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1 r3150_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r3150_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP_PRINCIPAL = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.RCAPS_NUM_TITULO) ? "-1" : "0";
            dta.RCAPS_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.RCAPS_NUM_CERTIFICADO) ? "-1" : "0";
            return dta;
        }

    }
}