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
    public class M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 : QueryBasis<M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PR.COD_EMPRESA ,
            PG.COD_EMPRESA_CAP
            INTO :PROD-COD-EMPRESA,
            :PARM-COD-EMPR-CAP
            FROM SEGUROS.PRODUTO PR,
            SEGUROS.PARAMETROS_GERAIS PG
            WHERE PR.COD_PRODUTO = :PROD-COD-PRODUTO
            AND PR.COD_EMPRESA = PG.COD_EMPRESA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PR.COD_EMPRESA 
							,
											PG.COD_EMPRESA_CAP
											FROM SEGUROS.PRODUTO PR
							,
											SEGUROS.PARAMETROS_GERAIS PG
											WHERE PR.COD_PRODUTO = '{this.PROD_COD_PRODUTO}'
											AND PR.COD_EMPRESA = PG.COD_EMPRESA";

            return query;
        }
        public string PROD_COD_EMPRESA { get; set; }
        public string PARM_COD_EMPR_CAP { get; set; }
        public string PROD_COD_PRODUTO { get; set; }

        public static M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 Execute(M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 m_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1)
        {
            var ths = m_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROD_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PARM_COD_EMPR_CAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}