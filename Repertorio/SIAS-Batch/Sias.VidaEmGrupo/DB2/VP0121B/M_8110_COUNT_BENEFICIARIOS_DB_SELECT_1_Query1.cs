using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1 : QueryBasis<M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WHOST-COUNT
            FROM SEGUROS.V0BENEFPROPAZ
            WHERE NRPROPAZ = :PROPVA-NRPROPAZ
            AND AGELOTE = 0
            AND DTLOTE = 0
            AND NRLOTE = 0
            AND NRSEQLOTE = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0BENEFPROPAZ
											WHERE NRPROPAZ = '{this.PROPVA_NRPROPAZ}'
											AND AGELOTE = 0
											AND DTLOTE = 0
											AND NRLOTE = 0
											AND NRSEQLOTE = 0
											WITH UR";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string PROPVA_NRPROPAZ { get; set; }

        public static M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1 Execute(M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1 m_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1)
        {
            var ths = m_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}