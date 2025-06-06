using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG009
{
    public class P3021_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P3021_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            , SEQ_PESSOA_HIST
            INTO :VG110-COD-PESSOA
            , :VG110-SEQ-PESSOA-HIST
            FROM SEGUROS.VG_C612_RELAC_PROPOSTA A
            WHERE A.NUM_PROPOSTA = :VG110-NUM-PROPOSTA
            AND A.SEQ_PESSOA_HIST =
            ( SELECT MAX(VW1.SEQ_PESSOA_HIST)
            FROM SEGUROS.VG_C612_RELAC_PROPOSTA VW1
            WHERE VW1.NUM_PROPOSTA = A.NUM_PROPOSTA )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											, SEQ_PESSOA_HIST
											FROM SEGUROS.VG_C612_RELAC_PROPOSTA A
											WHERE A.NUM_PROPOSTA = '{this.VG110_NUM_PROPOSTA}'
											AND A.SEQ_PESSOA_HIST =
											( SELECT MAX(VW1.SEQ_PESSOA_HIST)
											FROM SEGUROS.VG_C612_RELAC_PROPOSTA VW1
											WHERE VW1.NUM_PROPOSTA = A.NUM_PROPOSTA )
											WITH UR";

            return query;
        }
        public string VG110_COD_PESSOA { get; set; }
        public string VG110_SEQ_PESSOA_HIST { get; set; }
        public string VG110_NUM_PROPOSTA { get; set; }

        public static P3021_05_INICIO_DB_SELECT_1_Query1 Execute(P3021_05_INICIO_DB_SELECT_1_Query1 p3021_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p3021_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P3021_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P3021_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG110_COD_PESSOA = result[i++].Value?.ToString();
            dta.VG110_SEQ_PESSOA_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}