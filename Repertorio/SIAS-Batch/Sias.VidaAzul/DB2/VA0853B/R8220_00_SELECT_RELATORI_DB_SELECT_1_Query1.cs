using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1 : QueryBasis<R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODRELAT
            INTO :V0RELA-CODRELAT
            FROM SEGUROS.V0RELATORIOS
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND CODRELAT = 'PERDAO'
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODRELAT
											FROM SEGUROS.V0RELATORIOS
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND CODRELAT = 'PERDAO'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V0RELA_CODRELAT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1 Execute(R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1 r8220_00_SELECT_RELATORI_DB_SELECT_1_Query1)
        {
            var ths = r8220_00_SELECT_RELATORI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELA_CODRELAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}