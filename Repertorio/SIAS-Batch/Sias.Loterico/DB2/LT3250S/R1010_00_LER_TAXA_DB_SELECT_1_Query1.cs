using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3250S
{
    public class R1010_00_LER_TAXA_DB_SELECT_1_Query1 : QueryBasis<R1010_00_LER_TAXA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TAXA_IS_FENAL
            INTO :LOTTAX01-TAXA-IS-FENAL
            FROM SEGUROS.V0LOTTAXA01
            WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE
            AND COD_COBERTURA = :LOTTAX01-COD-COBERTURA
            AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL
            AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA
            AND MODALIDA_COBERTURA = :LOTTAX01-MODALIDA-COBERTURA
            AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG
            AND DTTERVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXA_IS_FENAL
											FROM SEGUROS.V0LOTTAXA01
											WHERE NUM_APOLICE = '{this.LOTTAX01_NUM_APOLICE}'
											AND COD_COBERTURA = '{this.LOTTAX01_COD_COBERTURA}'
											AND COD_LOT_FENAL = '{this.LOTTAX01_COD_LOT_FENAL}'
											AND RAMO_COBERTURA = '{this.LOTTAX01_RAMO_COBERTURA}'
											AND MODALIDA_COBERTURA = '{this.LOTTAX01_MODALIDA_COBERTURA}'
											AND '{this.LOTTAX01_DTINIVIG}' BETWEEN DTINIVIG
											AND DTTERVIG
											WITH UR";

            return query;
        }
        public string LOTTAX01_TAXA_IS_FENAL { get; set; }
        public string LOTTAX01_MODALIDA_COBERTURA { get; set; }
        public string LOTTAX01_RAMO_COBERTURA { get; set; }
        public string LOTTAX01_COD_COBERTURA { get; set; }
        public string LOTTAX01_COD_LOT_FENAL { get; set; }
        public string LOTTAX01_NUM_APOLICE { get; set; }
        public string LOTTAX01_DTINIVIG { get; set; }

        public static R1010_00_LER_TAXA_DB_SELECT_1_Query1 Execute(R1010_00_LER_TAXA_DB_SELECT_1_Query1 r1010_00_LER_TAXA_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_LER_TAXA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_LER_TAXA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_LER_TAXA_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTTAX01_TAXA_IS_FENAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}