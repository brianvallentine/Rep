using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :RELATORI-DATA-REFERENCIA
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'CB'
            AND COD_RELATORIO = 'CB7300B1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'CB'
											AND COD_RELATORIO = 'CB7300B1'
											WITH UR";

            return query;
        }
        public string RELATORI_DATA_REFERENCIA { get; set; }

        public static R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 Execute(R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 r0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0105_SELECT_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}