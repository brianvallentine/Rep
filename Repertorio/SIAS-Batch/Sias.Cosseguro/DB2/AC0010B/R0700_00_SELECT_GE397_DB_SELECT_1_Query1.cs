using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R0700_00_SELECT_GE397_DB_SELECT_1_Query1 : QueryBasis<R0700_00_SELECT_GE397_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(COUNT(*),+0)
            INTO :WHOST-QTDE-REG
            FROM SEGUROS.GE_ENDOS_COSSEG_COBER
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NUM_ENDOSSO = :V1HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.GE_ENDOS_COSSEG_COBER
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NUM_ENDOSSO = '{this.V1HISP_NRENDOS}'";

            return query;
        }
        public string WHOST_QTDE_REG { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R0700_00_SELECT_GE397_DB_SELECT_1_Query1 Execute(R0700_00_SELECT_GE397_DB_SELECT_1_Query1 r0700_00_SELECT_GE397_DB_SELECT_1_Query1)
        {
            var ths = r0700_00_SELECT_GE397_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_00_SELECT_GE397_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_00_SELECT_GE397_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDE_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}