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
    public class R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1 : QueryBasis<R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PESSOA_CONTRTE
            INTO :EF079-COD-PESSOA-CONTRTE
            FROM SEGUROS.EF_SEGURADO_OBJETO A,
            SEGUROS.EF_OBJ_CONTR_SEGUR B
            WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO
            AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR
            AND A.SEQ_TIPO_OBJ_SEG = :EF079-SEQ-TIPO-OBJ-SEG
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
				SELECT A.COD_PESSOA_CONTRTE
											FROM SEGUROS.EF_SEGURADO_OBJETO A
							,
											SEGUROS.EF_OBJ_CONTR_SEGUR B
											WHERE A.NUM_CONTRATO_SEGUR = '{this.EF072_NUM_CONTRATO}'
											AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR
											AND A.SEQ_TIPO_OBJ_SEG = '{this.EF079_SEQ_TIPO_OBJ_SEG}'
											AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG
											AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG
											AND A.STA_TITULAR = 'S'
											AND B.STA_OBJ_CONTR_SEG = 'A'
											AND B.COD_TIPO_OBJ_SEG = 2
											WITH UR";

            return query;
        }
        public string EF079_COD_PESSOA_CONTRTE { get; set; }
        public string EF079_SEQ_TIPO_OBJ_SEG { get; set; }
        public string EF072_NUM_CONTRATO { get; set; }

        public static R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1 Execute(R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1 r5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1)
        {
            var ths = r5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF079_COD_PESSOA_CONTRTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}