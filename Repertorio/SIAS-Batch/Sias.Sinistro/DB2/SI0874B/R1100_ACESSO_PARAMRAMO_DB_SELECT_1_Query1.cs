using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP
            INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG,
            :PARAMRAM-RAMO-AP
            FROM SEGUROS.PARAMETROS_RAMOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VGAPC
							, RAMO_VG
							, RAMO_AP
											FROM SEGUROS.PARAMETROS_RAMOS
											WITH UR";

            return query;
        }
        public string PARAMRAM_RAMO_VGAPC { get; set; }
        public string PARAMRAM_RAMO_VG { get; set; }
        public string PARAMRAM_RAMO_AP { get; set; }

        public static R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1 Execute(R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1 r1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = r1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMRAM_RAMO_VGAPC = result[i++].Value?.ToString();
            dta.PARAMRAM_RAMO_VG = result[i++].Value?.ToString();
            dta.PARAMRAM_RAMO_AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}