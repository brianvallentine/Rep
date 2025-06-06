using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            MATRIC_INDICADOR
            INTO
            :PLANOAGE-MATRIC-INDICADOR:VIND-MATRIC
            FROM SEGUROS.PLANO_AGENCIAMENTO
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											MATRIC_INDICADOR
											FROM SEGUROS.PLANO_AGENCIAMENTO
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string PLANOAGE_MATRIC_INDICADOR { get; set; }
        public string VIND_MATRIC { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1 r1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_PLANOAGE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOAGE_MATRIC_INDICADOR = result[i++].Value?.ToString();
            dta.VIND_MATRIC = string.IsNullOrWhiteSpace(dta.PLANOAGE_MATRIC_INDICADOR) ? "-1" : "0";
            return dta;
        }

    }
}