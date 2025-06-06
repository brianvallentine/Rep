using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1 : QueryBasis<R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QT-REG
            FROM SEGUROS.CB_APOLICE_VIGPROP
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND SITUACAO = 'Y'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.CB_APOLICE_VIGPROP
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND SITUACAO = 'Y'
											WITH UR";

            return query;
        }
        public string WS_QT_REG { get; set; }
        public string V1PARC_NUM_APOL { get; set; }

        public static R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1 Execute(R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1 r4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1)
        {
            var ths = r4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4100_00_MONTA_PREMIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QT_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}