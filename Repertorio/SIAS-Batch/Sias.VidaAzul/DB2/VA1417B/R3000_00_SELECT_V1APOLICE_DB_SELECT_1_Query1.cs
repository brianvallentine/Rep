using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1417B
{
    public class R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 : QueryBasis<R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME
            INTO :V1APOL-NOMEAPOL
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :V0HCON-APOLICE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.V0HCON_APOLICE}'";

            return query;
        }
        public string V1APOL_NOMEAPOL { get; set; }
        public string V0HCON_APOLICE { get; set; }

        public static R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 Execute(R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 r3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APOL_NOMEAPOL = result[i++].Value?.ToString();
            return dta;
        }

    }
}