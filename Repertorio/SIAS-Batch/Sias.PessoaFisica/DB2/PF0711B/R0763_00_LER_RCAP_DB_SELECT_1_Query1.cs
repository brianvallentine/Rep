using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0711B
{
    public class R0763_00_LER_RCAP_DB_SELECT_1_Query1 : QueryBasis<R0763_00_LER_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_RCAP ,
            DATA_CADASTRAMENTO ,
            DATA_MOVIMENTO ,
            AGE_COBRANCA
            INTO :DCLRCAPS.RCAPS-VAL-RCAP ,
            :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO,
            :DCLRCAPS.RCAPS-DATA-MOVIMENTO ,
            :DCLRCAPS.RCAPS-AGE-COBRANCA:VIND-RCAPS-AGE
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO
            AND COD_OPERACAO BETWEEN 100 AND 199
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_RCAP 
							,
											DATA_CADASTRAMENTO 
							,
											DATA_MOVIMENTO 
							,
											AGE_COBRANCA
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'
											AND COD_OPERACAO BETWEEN 100 AND 199
											WITH UR";

            return query;
        }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string VIND_RCAPS_AGE { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static R0763_00_LER_RCAP_DB_SELECT_1_Query1 Execute(R0763_00_LER_RCAP_DB_SELECT_1_Query1 r0763_00_LER_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r0763_00_LER_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0763_00_LER_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0763_00_LER_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.RCAPS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.VIND_RCAPS_AGE = string.IsNullOrWhiteSpace(dta.RCAPS_AGE_COBRANCA) ? "-1" : "0";
            return dta;
        }

    }
}