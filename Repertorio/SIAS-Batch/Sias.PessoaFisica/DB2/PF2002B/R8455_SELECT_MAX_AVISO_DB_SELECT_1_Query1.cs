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
    public class R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1 : QueryBasis<R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUMFITA) + 1, 1)
            INTO :V0MCOB-NUMFITA
            FROM SEGUROS.V0MOVICOB
            WHERE DTMOVTO > '2016-12-01'
            AND AGENCIA IN (7001, 7005, 7996, 7003, 7800, 7828)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUMFITA) + 1
							, 1)
											FROM SEGUROS.V0MOVICOB
											WHERE DTMOVTO > '2016-12-01'
											AND AGENCIA IN (7001
							, 7005
							, 7996
							, 7003
							, 7800
							, 7828)
											WITH UR";

            return query;
        }
        public string V0MCOB_NUMFITA { get; set; }

        public static R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1 Execute(R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1 r8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1)
        {
            var ths = r8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8455_SELECT_MAX_AVISO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MCOB_NUMFITA = result[i++].Value?.ToString();
            return dta;
        }

    }
}