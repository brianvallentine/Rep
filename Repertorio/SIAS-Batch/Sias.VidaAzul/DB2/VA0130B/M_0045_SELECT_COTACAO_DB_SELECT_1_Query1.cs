using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0045_SELECT_COTACAO_DB_SELECT_1_Query1 : QueryBasis<M_0045_SELECT_COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG
            INTO :COTACAO-DTINIVIG
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :VG077-COD-MOEDA
            AND DTINIVIG = :SISTEMA-DTTERCOT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.VG077_COD_MOEDA}'
											AND DTINIVIG = '{this.SISTEMA_DTTERCOT}'
											WITH UR";

            return query;
        }
        public string COTACAO_DTINIVIG { get; set; }
        public string SISTEMA_DTTERCOT { get; set; }
        public string VG077_COD_MOEDA { get; set; }

        public static M_0045_SELECT_COTACAO_DB_SELECT_1_Query1 Execute(M_0045_SELECT_COTACAO_DB_SELECT_1_Query1 m_0045_SELECT_COTACAO_DB_SELECT_1_Query1)
        {
            var ths = m_0045_SELECT_COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0045_SELECT_COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0045_SELECT_COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.COTACAO_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}