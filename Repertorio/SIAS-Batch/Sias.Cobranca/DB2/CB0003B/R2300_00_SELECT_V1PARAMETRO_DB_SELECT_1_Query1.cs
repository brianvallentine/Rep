using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODUNIMO
            ,A.DIFPRM
            INTO :V1PARM-CODUNIMO
            ,:V1PARM-DIFPRM
            FROM SEGUROS.V1PARAMETRO A
            ,SEGUROS.PRODUTO B
            WHERE
            B.COD_PRODUTO = :V1ENDO-CODPRODU
            AND A.COD_EMPRESA = B.COD_EMPRESA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODUNIMO
											,A.DIFPRM
											FROM SEGUROS.V1PARAMETRO A
											,SEGUROS.PRODUTO B
											WHERE
											B.COD_PRODUTO = '{this.V1ENDO_CODPRODU}'
											AND A.COD_EMPRESA = B.COD_EMPRESA
											WITH UR";

            return query;
        }
        public string V1PARM_CODUNIMO { get; set; }
        public string V1PARM_DIFPRM { get; set; }
        public string V1ENDO_CODPRODU { get; set; }

        public static R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1 r2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARM_CODUNIMO = result[i++].Value?.ToString();
            dta.V1PARM_DIFPRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}