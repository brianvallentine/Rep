using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MODALIDADE
            INTO :WS-APOL-COD-MODALIDADE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MODALIDADE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.V1SEGV_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string WS_APOL_COD_MODALIDADE { get; set; }
        public string V1SEGV_NUM_APOLICE { get; set; }

        public static M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1 m_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_APOL_COD_MODALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}