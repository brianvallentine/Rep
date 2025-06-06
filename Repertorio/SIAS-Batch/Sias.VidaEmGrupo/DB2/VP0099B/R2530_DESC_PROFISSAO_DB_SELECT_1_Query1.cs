using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2530_DESC_PROFISSAO_DB_SELECT_1_Query1 : QueryBasis<R2530_DESC_PROFISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_CBO
            INTO :CBO-DESCR-CBO
            FROM SEGUROS.CBO
            WHERE COD_CBO = :PESSOFIS-COD-CBO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DESCR_CBO
											FROM SEGUROS.CBO
											WHERE COD_CBO = '{this.PESSOFIS_COD_CBO}'
											WITH UR";

            return query;
        }
        public string CBO_DESCR_CBO { get; set; }
        public string PESSOFIS_COD_CBO { get; set; }

        public static R2530_DESC_PROFISSAO_DB_SELECT_1_Query1 Execute(R2530_DESC_PROFISSAO_DB_SELECT_1_Query1 r2530_DESC_PROFISSAO_DB_SELECT_1_Query1)
        {
            var ths = r2530_DESC_PROFISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2530_DESC_PROFISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2530_DESC_PROFISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}