using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1000_00_PROCESSA_REGISTRO_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CAST(:WHOST-VLR-RELAT AS INT)
            INTO :WHOST-SIN-RELAT
            FROM SYSIBM.SYSDUMMY1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CAST('{this.WHOST_VLR_RELAT}' AS INT)
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WHOST_SIN_RELAT { get; set; }
        public string WHOST_VLR_RELAT { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_Query1 Execute(R1000_00_PROCESSA_REGISTRO_Query1 r1000_00_PROCESSA_REGISTRO_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_Query1();
            var i = 0;
            dta.WHOST_SIN_RELAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}