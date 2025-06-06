using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R3250_00_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R3250_00_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORGAO_EMISSOR ,
            ULT_PROP_AUTOMAT
            INTO :FONTES-ORGAO-EMISSOR ,
            :FONTES-ULT-PROP-AUTOMAT
            FROM SEGUROS.FONTES
            WHERE COD_FONTE =
            :FONTES-COD-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORGAO_EMISSOR 
							,
											ULT_PROP_AUTOMAT
											FROM SEGUROS.FONTES
											WHERE COD_FONTE =
											'{this.FONTES_COD_FONTE}'
											WITH UR";

            return query;
        }
        public string FONTES_ORGAO_EMISSOR { get; set; }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string FONTES_COD_FONTE { get; set; }

        public static R3250_00_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R3250_00_SELECT_FONTES_DB_SELECT_1_Query1 r3250_00_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r3250_00_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3250_00_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3250_00_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.FONTES_ULT_PROP_AUTOMAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}