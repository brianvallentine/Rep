using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1 : QueryBasis<R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESCNEG
            INTO :V1ACEF-CODESCNEG
            FROM SEGUROS.V1AGENCIACEF
            WHERE COD_AGENCIA = :V0BILH-AGECOBR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESCNEG
											FROM SEGUROS.V1AGENCIACEF
											WHERE COD_AGENCIA = '{this.V0BILH_AGECOBR}'
											WITH UR";

            return query;
        }
        public string V1ACEF_CODESCNEG { get; set; }
        public string V0BILH_AGECOBR { get; set; }

        public static R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1 Execute(R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1 r3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1)
        {
            var ths = r3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_ACUMULA_BILHETE_DB_SELECT_4_Query1();
            var i = 0;
            dta.V1ACEF_CODESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}