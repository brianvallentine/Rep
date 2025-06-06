using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            COD_CLIENTE ,
            OCORR_ENDERECO
            INTO :V0TOMA-CODCLIEN ,
            :V0TOMA-OCORR-END
            FROM SEGUROS.V0TOMADOR
            WHERE FONTE = :V1ENDO-FONTE
            AND NRPROPOS = :V1ENDO-NRPROPOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE 
							,
											OCORR_ENDERECO
											FROM SEGUROS.V0TOMADOR
											WHERE FONTE = '{this.V1ENDO_FONTE}'
											AND NRPROPOS = '{this.V1ENDO_NRPROPOS}'";

            return query;
        }
        public string V0TOMA_CODCLIEN { get; set; }
        public string V0TOMA_OCORR_END { get; set; }
        public string V1ENDO_NRPROPOS { get; set; }
        public string V1ENDO_FONTE { get; set; }

        public static R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1 r2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_V0TOMADOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0TOMA_CODCLIEN = result[i++].Value?.ToString();
            dta.V0TOMA_OCORR_END = result[i++].Value?.ToString();
            return dta;
        }

    }
}