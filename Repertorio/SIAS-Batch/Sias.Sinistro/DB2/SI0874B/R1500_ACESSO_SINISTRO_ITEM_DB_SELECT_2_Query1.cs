using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1 : QueryBasis<R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :APOLICES-COD-CLIENTE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1 Execute(R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1 r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1)
        {
            var ths = r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1();
            var i = 0;
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}