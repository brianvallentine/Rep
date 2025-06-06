using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0811B
{
    public class M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :APOLICES-COD-CLIENTE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1 m_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}