using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO
            INTO :SEGURHIS-DATA-MOVIMENTO
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND COD_OPERACAO = 202
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND COD_OPERACAO = 202
											WITH UR";

            return query;
        }
        public string SEGURHIS_DATA_MOVIMENTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1 Execute(R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1 r1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}