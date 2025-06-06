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
    public class R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1 : QueryBasis<R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(A.SEQ_TIPO_OBJ_SEG),0)
            INTO :EF079-SEQ-TIPO-OBJ-SEG
            FROM SEGUROS.EF_SEGURADO_OBJETO A,
            SEGUROS.EF_OBJ_CONTR_SEGUR B
            WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO
            AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR
            AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG
            AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG
            AND A.STA_TITULAR = 'S'
            AND B.STA_OBJ_CONTR_SEG = 'A'
            AND B.COD_TIPO_OBJ_SEG = 2
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(A.SEQ_TIPO_OBJ_SEG)
							,0)
											FROM SEGUROS.EF_SEGURADO_OBJETO A
							,
											SEGUROS.EF_OBJ_CONTR_SEGUR B
											WHERE A.NUM_CONTRATO_SEGUR = '{this.EF072_NUM_CONTRATO}'
											AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR
											AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG
											AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG
											AND A.STA_TITULAR = 'S'
											AND B.STA_OBJ_CONTR_SEG = 'A'
											AND B.COD_TIPO_OBJ_SEG = 2
											WITH UR";

            return query;
        }
        public string EF079_SEQ_TIPO_OBJ_SEG { get; set; }
        public string EF072_NUM_CONTRATO { get; set; }

        public static R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1 Execute(R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1 r4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1)
        {
            var ths = r4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF079_SEQ_TIPO_OBJ_SEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}