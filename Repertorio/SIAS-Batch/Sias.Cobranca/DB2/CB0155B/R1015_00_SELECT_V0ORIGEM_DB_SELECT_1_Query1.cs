using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1 : QueryBasis<R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCRICAO_ORIGEM
            INTO :ORIGEAVI-DESCRICAO-ORIGEM
            FROM SEGUROS.ORIGEM_AVISO
            WHERE ORIGEM_AVISO = :ORIGEAVI-ORIGEM-AVISO
            AND COD_EMPRESA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCRICAO_ORIGEM
											FROM SEGUROS.ORIGEM_AVISO
											WHERE ORIGEM_AVISO = '{this.ORIGEAVI_ORIGEM_AVISO}'
											AND COD_EMPRESA = 0";

            return query;
        }
        public string ORIGEAVI_DESCRICAO_ORIGEM { get; set; }
        public string ORIGEAVI_ORIGEM_AVISO { get; set; }

        public static R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1 Execute(R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1 r1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1)
        {
            var ths = r1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1015_00_SELECT_V0ORIGEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.ORIGEAVI_DESCRICAO_ORIGEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}