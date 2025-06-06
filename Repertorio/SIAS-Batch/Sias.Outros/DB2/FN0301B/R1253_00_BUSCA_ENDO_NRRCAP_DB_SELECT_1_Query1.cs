using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1 : QueryBasis<R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRRCAP
            INTO :V0ENDO-NRRCAP
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V1ENDO-NUMAPOL
            AND NRENDOS = 0
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRRCAP
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V1ENDO_NUMAPOL}'
											AND NRENDOS = 0
											WITH UR";

            return query;
        }
        public string V0ENDO_NRRCAP { get; set; }
        public string V1ENDO_NUMAPOL { get; set; }

        public static R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1 Execute(R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1 r1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1)
        {
            var ths = r1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_NRRCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}