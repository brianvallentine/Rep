using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0403B
{
    public class R0100_00_INICIALIZA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_INICIALIZA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE,
            CURRENT DATE,
            DAYS (CURRENT DATE)
            INTO :V1SIST-DTMOVABE,
            :V1SIST-DTHOJE,
            :V1SIST-QTDIAS
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'PF'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
							,
											CURRENT DATE
							,
											DAYS (CURRENT DATE)
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'PF'
											WITH UR";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTHOJE { get; set; }
        public string V1SIST_QTDIAS { get; set; }

        public static R0100_00_INICIALIZA_DB_SELECT_1_Query1 Execute(R0100_00_INICIALIZA_DB_SELECT_1_Query1 r0100_00_INICIALIZA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_INICIALIZA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_INICIALIZA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_INICIALIZA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTHOJE = result[i++].Value?.ToString();
            dta.V1SIST_QTDIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}