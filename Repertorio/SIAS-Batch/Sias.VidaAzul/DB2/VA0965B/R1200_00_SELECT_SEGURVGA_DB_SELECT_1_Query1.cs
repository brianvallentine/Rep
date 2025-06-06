using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0965B
{
    public class R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CERTIFICADO,
            NUM_APOLICE ,
            COD_CLIENTE
            INTO
            :SEGURVGA-NUM-CERTIFICADO,
            :SEGURVGA-NUM-APOLICE ,
            :SEGURVGA-COD-CLIENTE
            FROM
            SEGUROS.SEGURADOS_VGAP
            WHERE
            NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CERTIFICADO
							,
											NUM_APOLICE 
							,
											COD_CLIENTE
											FROM
											SEGUROS.SEGURADOS_VGAP
											WHERE
											NUM_CERTIFICADO = '{this.SINISMES_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }

        public static R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}