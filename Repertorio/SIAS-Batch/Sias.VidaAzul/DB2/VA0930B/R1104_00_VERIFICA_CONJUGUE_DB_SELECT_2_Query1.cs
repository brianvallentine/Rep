using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1 : QueryBasis<R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CARREGA_CONJUGE
            INTO :CONDITEC-CARREGA-CONJUGE
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CARREGA_CONJUGE
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1 Execute(R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1 r1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1)
        {
            var ths = r1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1();
            var i = 0;
            dta.CONDITEC_CARREGA_CONJUGE = result[i++].Value?.ToString();
            return dta;
        }

    }
}