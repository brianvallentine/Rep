using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202S
{
    public class R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1 : QueryBasis<R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CONTRATO
            INTO :EF072-NUM-CONTRATO
            FROM SEGUROS.EF_CONTR_SEG_HABIT
            WHERE NOM_ARQUIVO = 'EF001'
            AND NUM_CONTRATO_TERC = :EF072-NUM-CONTRATO-TERC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CONTRATO
											FROM SEGUROS.EF_CONTR_SEG_HABIT
											WHERE NOM_ARQUIVO = 'EF001'
											AND NUM_CONTRATO_TERC = '{this.EF072_NUM_CONTRATO_TERC}'
											WITH UR";

            return query;
        }
        public string EF072_NUM_CONTRATO { get; set; }
        public string EF072_NUM_CONTRATO_TERC { get; set; }

        public static R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1 Execute(R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1 r1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1)
        {
            var ths = r1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF072_NUM_CONTRATO = result[i++].Value?.ToString();
            return dta;
        }

    }
}