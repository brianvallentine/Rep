using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODUNIMO,
            VLCRUZAD
            INTO :V1EN-COD-MOEDA-IMP,
            :DVLCRUZAD-IMP
            FROM SEGUROS.V1MOEDA
            WHERE TIPO_MOEDA = '0'
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODUNIMO
							,
											VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE TIPO_MOEDA = '0'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V1EN_COD_MOEDA_IMP { get; set; }
        public string DVLCRUZAD_IMP { get; set; }

        public static M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1 Execute(M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1 m_080_000_LER_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_080_000_LER_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1EN_COD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.DVLCRUZAD_IMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}