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
    public class R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1 : QueryBasis<R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :APOLIAUT-COD-CLIENTE
            FROM SEGUROS.APOLICE_AUTO
            WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE
            AND NUM_ENDOSSO = :SINISMES-NUM-ENDOSSO
            AND NUM_ITEM = :SINISAUT-NUM-ITEM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.APOLICE_AUTO
											WHERE NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.SINISMES_NUM_ENDOSSO}'
											AND NUM_ITEM = '{this.SINISAUT_NUM_ITEM}'
											WITH UR";

            return query;
        }
        public string APOLIAUT_COD_CLIENTE { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_ENDOSSO { get; set; }
        public string SINISAUT_NUM_ITEM { get; set; }

        public static R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1 Execute(R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1 r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1)
        {
            var ths = r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1();
            var i = 0;
            dta.APOLIAUT_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}