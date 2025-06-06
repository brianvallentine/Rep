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
    public class M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(B.OCORHIST), 0)
            INTO :SOCORR-HISTORICO
            FROM SEGUROS.V1SEGURAVG A,
            SEGUROS.V0COBERAPOL B
            WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ITEM = B.NUM_ITEM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(B.OCORHIST)
							, 0)
											FROM SEGUROS.V1SEGURAVG A
							,
											SEGUROS.V0COBERAPOL B
											WHERE A.NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ITEM = B.NUM_ITEM
											WITH UR";

            return query;
        }
        public string SOCORR_HISTORICO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 Execute(M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 m_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = m_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2500_SELECT_V0COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.SOCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}