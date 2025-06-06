using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1111B
{
    public class R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1 : QueryBasis<R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CONTRATO_TERC
            INTO :EF150-NUM-CONTR-TERC
            FROM SEGUROS.EF_CONTR_SEG_HABIT
            WHERE NOM_ARQUIVO = 'EF001'
            AND NUM_CONTRATO = :EF072-NUM-CONTRATO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CONTRATO_TERC
											FROM SEGUROS.EF_CONTR_SEG_HABIT
											WHERE NOM_ARQUIVO = 'EF001'
											AND NUM_CONTRATO = '{this.EF072_NUM_CONTRATO}'
											WITH UR";

            return query;
        }
        public string EF150_NUM_CONTR_TERC { get; set; }
        public string EF072_NUM_CONTRATO { get; set; }

        public static R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1 Execute(R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1 r21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1)
        {
            var ths = r21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF150_NUM_CONTR_TERC = result[i++].Value?.ToString();
            return dta;
        }

    }
}