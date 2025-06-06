using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA ,
            NUM_ITEM
            INTO :SEGURVGA-DATA-INIVIGENCIA ,
            :SEGURVGA-NUM-ITEM
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA 
							,
											NUM_ITEM
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}