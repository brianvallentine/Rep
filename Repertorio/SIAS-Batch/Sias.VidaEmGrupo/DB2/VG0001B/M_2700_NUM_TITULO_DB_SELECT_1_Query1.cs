using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_2700_NUM_TITULO_DB_SELECT_1_Query1 : QueryBasis<M_2700_NUM_TITULO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :BANCOS-NUM-TITULO
            FROM SEGUROS.BANCOS
            WHERE COD_BANCO = 104
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.BANCOS
											WHERE COD_BANCO = 104
											WITH UR";

            return query;
        }
        public string BANCOS_NUM_TITULO { get; set; }

        public static M_2700_NUM_TITULO_DB_SELECT_1_Query1 Execute(M_2700_NUM_TITULO_DB_SELECT_1_Query1 m_2700_NUM_TITULO_DB_SELECT_1_Query1)
        {
            var ths = m_2700_NUM_TITULO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2700_NUM_TITULO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2700_NUM_TITULO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BANCOS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}