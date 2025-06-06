using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 : QueryBasis<R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CARREGA_CONJUGE
            INTO :CONDITEC-CARREGA-CONJUGE
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE =
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE
            AND COD_SUBGRUPO =
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CARREGA_CONJUGE
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE =
											'{this.PROPSSVD_NUM_APOLICE}'
											AND COD_SUBGRUPO =
											'{this.PROPSSVD_COD_SUBGRUPO}'";

            return query;
        }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }

        public static R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 Execute(R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1)
        {
            var ths = r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_CARREGA_CONJUGE = result[i++].Value?.ToString();
            return dta;
        }

    }
}