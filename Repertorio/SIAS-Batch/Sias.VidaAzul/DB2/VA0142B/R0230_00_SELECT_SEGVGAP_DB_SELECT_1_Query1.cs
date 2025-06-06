using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0142B
{
    public class R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1 : QueryBasis<R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :SEGVGAP-NUM-ITEM
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGVGAP_NUM_ITEM { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }

        public static R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1 Execute(R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1 r0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0230_00_SELECT_SEGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVGAP_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}