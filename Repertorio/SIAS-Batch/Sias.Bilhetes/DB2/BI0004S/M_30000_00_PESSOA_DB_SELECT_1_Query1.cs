using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0004S
{
    public class M_30000_00_PESSOA_DB_SELECT_1_Query1 : QueryBasis<M_30000_00_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            INTO :WS-COD-PES-004
            FROM SEGUROS.PESSOA
            WHERE COD_PESSOA = :BI0004L-E-COD-PES
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											FROM SEGUROS.PESSOA
											WHERE COD_PESSOA = '{this.BI0004L_E_COD_PES}'
											WITH UR";

            return query;
        }
        public string WS_COD_PES_004 { get; set; }
        public string BI0004L_E_COD_PES { get; set; }

        public static M_30000_00_PESSOA_DB_SELECT_1_Query1 Execute(M_30000_00_PESSOA_DB_SELECT_1_Query1 m_30000_00_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = m_30000_00_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_30000_00_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_30000_00_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_PES_004 = result[i++].Value?.ToString();
            return dta;
        }

    }
}