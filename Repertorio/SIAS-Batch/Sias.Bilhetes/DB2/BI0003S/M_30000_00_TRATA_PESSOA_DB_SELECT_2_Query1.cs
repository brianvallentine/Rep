using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 : QueryBasis<M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_PESSOA),0)
            INTO :WS-COD-PES-ATU
            FROM SEGUROS.PESSOA_JURIDICA
            WHERE CGC = :DCLPESSOA-JURIDICA.CGC
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_PESSOA)
							,0)
											FROM SEGUROS.PESSOA_JURIDICA
											WHERE CGC = '{this.CGC}'
											WITH UR";

            return query;
        }
        public string WS_COD_PES_ATU { get; set; }
        public string CGC { get; set; }

        public static M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 Execute(M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1)
        {
            var ths = m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_COD_PES_ATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}