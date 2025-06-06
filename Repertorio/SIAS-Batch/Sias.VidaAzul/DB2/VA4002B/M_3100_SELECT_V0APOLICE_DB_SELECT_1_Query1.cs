using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            VALUE(NUM_ITEM, 0) + 1,
            MODALIDA,
            RAMO
            INTO :APOLICES-NUM-APOLICE,
            :APOLICES-NUM-ITEM,
            :APOLICES-COD-MODALIDADE,
            :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											VALUE(NUM_ITEM
							, 0) + 1
							,
											MODALIDA
							,
											RAMO
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string APOLICES_NUM_ITEM { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }

        public static M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1 Execute(M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1 m_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICES_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}