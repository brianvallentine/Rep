using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1 : QueryBasis<R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF
            INTO :WHOST-NRCERTIF
            FROM SEGUROS.V0FUNDOCOMISVA
            WHERE NUM_TERMO = :TERMOADE-NUM-TERMO
            AND NUM_PARCELA = :V0HCTA-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
											FROM SEGUROS.V0FUNDOCOMISVA
											WHERE NUM_TERMO = '{this.TERMOADE_NUM_TERMO}'
											AND NUM_PARCELA = '{this.V0HCTA_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string WHOST_NRCERTIF { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1 Execute(R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1 r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1)
        {
            var ths = r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1();
            var i = 0;
            dta.WHOST_NRCERTIF = result[i++].Value?.ToString();
            return dta;
        }

    }
}