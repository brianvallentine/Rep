using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1 : QueryBasis<R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTH_INCLUSAO
            INTO :ADPROGRA-DTH-INCLUSAO
            FROM SEGUROS.AD_PROGRAMA
            WHERE NOM_PROGRAMA = :ADPROGRA-NOM-PROGRAMA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTH_INCLUSAO
											FROM SEGUROS.AD_PROGRAMA
											WHERE NOM_PROGRAMA = '{this.ADPROGRA_NOM_PROGRAMA}'";

            return query;
        }
        public string ADPROGRA_DTH_INCLUSAO { get; set; }
        public string ADPROGRA_NOM_PROGRAMA { get; set; }

        public static R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1 Execute(R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1 r0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1();
            var i = 0;
            dta.ADPROGRA_DTH_INCLUSAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}