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
    public class R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1 : QueryBasis<R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_MATRI_VENDEDOR,
            COD_PRODUTO,
            AGE_COBRANCA
            INTO :PROPOVA-NUM-MATRI-VENDEDOR,
            :PROPOVA-COD-PRODUTO,
            :PROPOVA-AGE-COBRANCA
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_MATRI_VENDEDOR
							,
											COD_PRODUTO
							,
											AGE_COBRANCA
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.SEGURVGA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1 Execute(R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1 r1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1)
        {
            var ths = r1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1();
            var i = 0;
            dta.PROPOVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}