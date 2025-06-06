using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO_IX),+0)
            INTO :V0PARC-PRMTAR-IX
            FROM SEGUROS.V0PARCELA
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = :V0HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO_IX)
							,+0)
											FROM SEGUROS.V0PARCELA
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = '{this.V0HISP_NRENDOS}'";

            return query;
        }
        public string V0PARC_PRMTAR_IX { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 Execute(R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 r1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1550_00_SELECT_V0PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_PRMTAR_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}