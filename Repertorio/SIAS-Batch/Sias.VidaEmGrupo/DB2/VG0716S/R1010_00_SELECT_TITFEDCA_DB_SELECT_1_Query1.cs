using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0716S
{
    public class R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1 : QueryBasis<R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTITFDCAP
            INTO :MOVFEDCA-NRTITFDCAP
            FROM SEGUROS.TITULOS_FED_CAP_VA
            WHERE NUM_CERTIFICADO = :MOVFEDCA-NUM-PROPOSTA
            AND DATA_INIVIGENCIA = '0001-01-01'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTITFDCAP
											FROM SEGUROS.TITULOS_FED_CAP_VA
											WHERE NUM_CERTIFICADO = '{this.MOVFEDCA_NUM_PROPOSTA}'
											AND DATA_INIVIGENCIA = '0001-01-01'";

            return query;
        }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string MOVFEDCA_NUM_PROPOSTA { get; set; }

        public static R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1 Execute(R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1 r1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_SELECT_TITFEDCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVFEDCA_NRTITFDCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}