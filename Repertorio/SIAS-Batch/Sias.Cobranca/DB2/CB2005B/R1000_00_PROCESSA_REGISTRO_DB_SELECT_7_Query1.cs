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
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCIOF
            INTO :V1RIND-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :V1BILC-RAMOFR
            AND DTINIVIG <= :V0BILH-DTQITBCO
            AND DTTERVIG >= :V0BILH-DTQITBCO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.V1BILC_RAMOFR}'
											AND DTINIVIG <= '{this.V0BILH_DTQITBCO}'
											AND DTTERVIG >= '{this.V0BILH_DTQITBCO}'
											WITH UR";

            return query;
        }
        public string V1RIND_PCIOF { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V1BILC_RAMOFR { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1();
            var i = 0;
            dta.V1RIND_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}