using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0139B
{
    public class R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_INICIAL ,
            DATA_REFERENCIA
            INTO :RELATORI-PERI-INICIAL ,
            :RELATORI-DATA-REFERENCIA
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'CO'
            AND COD_RELATORIO = 'CO0399B1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_INICIAL 
							,
											DATA_REFERENCIA
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'CO'
											AND COD_RELATORIO = 'CO0399B1'";

            return query;
        }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_DATA_REFERENCIA { get; set; }

        public static R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}