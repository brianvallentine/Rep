using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1 : QueryBasis<M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CBO
            INTO :PF062-COD-CBO
            FROM SEGUROS.PF_CBO
            WHERE NUM_PROPOSTA_SIVPF = :WS-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CBO
											FROM SEGUROS.PF_CBO
											WHERE NUM_PROPOSTA_SIVPF = '{this.WS_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PF062_COD_CBO { get; set; }
        public string WS_NUM_CERTIFICADO { get; set; }

        public static M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1 Execute(M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1 m_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1)
        {
            var ths = m_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PF062_COD_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}