using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R3000_10_CONTINUA_DB_SELECT_1_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT AGECOBR,
            DTQITBCO
            INTO :V1COFE-AGECOBR,
            :V1COFE-DTQITBCO
            FROM SEGUROS.V1COMISSAO_FENAE
            WHERE NUMBIL = :V1COFE-NUMBIL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT AGECOBR
							,
											DTQITBCO
											FROM SEGUROS.V1COMISSAO_FENAE
											WHERE NUMBIL = '{this.V1COFE_NUMBIL}'
											WITH UR";

            return query;
        }
        public string V1COFE_AGECOBR { get; set; }
        public string V1COFE_DTQITBCO { get; set; }
        public string V1COFE_NUMBIL { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_1_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_1_Query1 r3000_10_CONTINUA_DB_SELECT_1_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1COFE_AGECOBR = result[i++].Value?.ToString();
            dta.V1COFE_DTQITBCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}