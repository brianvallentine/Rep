using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1 : QueryBasis<R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :TERMOADE-COD-CLIENTE
            FROM SEGUROS.TERMO_ADESAO
            WHERE NUM_TERMO = :RELATORI-NUM-TITULO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.TERMO_ADESAO
											WHERE NUM_TERMO = '{this.RELATORI_NUM_TITULO}'
											WITH UR";

            return query;
        }
        public string TERMOADE_COD_CLIENTE { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1 Execute(R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1 r1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1)
        {
            var ths = r1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1();
            var i = 0;
            dta.TERMOADE_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}