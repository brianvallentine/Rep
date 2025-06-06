using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1 : QueryBasis<R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALDEP
            INTO :V3IRF-VALDEP
            FROM SEGUROS.V1IRFONTE
            WHERE (:V1SIST-DTMOVABE BETWEEN DTINIVIG
            AND DTTERVIG)
            AND (:V2IRF-VALBRU BETWEEN LIMINF
            AND LIMSUP)
            AND TPPESSOA = :V1FAVO-TPPESSOA
            AND CODVIN = :V2FAVO-CODVIN
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALDEP
											FROM SEGUROS.V1IRFONTE
											WHERE ('{this.V1SIST_DTMOVABE}' BETWEEN DTINIVIG
											AND DTTERVIG)
											AND ('{this.V2IRF_VALBRU}' BETWEEN LIMINF
											AND LIMSUP)
											AND TPPESSOA = '{this.V1FAVO_TPPESSOA}'
											AND CODVIN = '{this.V2FAVO_CODVIN}'";

            return query;
        }
        public string V3IRF_VALDEP { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1FAVO_TPPESSOA { get; set; }
        public string V2FAVO_CODVIN { get; set; }
        public string V2IRF_VALBRU { get; set; }

        public static R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1 Execute(R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1 r0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1)
        {
            var ths = r0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V3IRF_VALDEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}