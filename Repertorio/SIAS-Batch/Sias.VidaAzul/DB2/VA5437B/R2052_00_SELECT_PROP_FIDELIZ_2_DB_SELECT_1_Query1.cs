using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1 : QueryBasis<R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DATA_PROPOSTA, :SVA-DTQUIT)
            INTO :PROPOFID-DATA-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :WHOST-NRCERTIF
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DATA_PROPOSTA
							, '{this.SVA_DTQUIT}')
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.WHOST_NRCERTIF}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string WHOST_NRCERTIF { get; set; }
        public string SVA_DTQUIT { get; set; }

        public static R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1 Execute(R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1 r2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1)
        {
            var ths = r2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}