using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1 : QueryBasis<R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALCPR
            INTO :V0VLCRUZAD-IMP
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = :V1HSEG-MOEDA-IMP
            AND DTINIVIG <= :V1HSEG-DT-MOVTO
            AND DTTERVIG >= :V1HSEG-DT-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALCPR
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = '{this.V1HSEG_MOEDA_IMP}'
											AND DTINIVIG <= '{this.V1HSEG_DT_MOVTO}'
											AND DTTERVIG >= '{this.V1HSEG_DT_MOVTO}'";

            return query;
        }
        public string V0VLCRUZAD_IMP { get; set; }
        public string V1HSEG_MOEDA_IMP { get; set; }
        public string V1HSEG_DT_MOVTO { get; set; }

        public static R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1 Execute(R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1 r0224_35_OBTER_MOEDA_DB_SELECT_1_Query1)
        {
            var ths = r0224_35_OBTER_MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0224_35_OBTER_MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0VLCRUZAD_IMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}