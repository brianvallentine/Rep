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
    public class R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA
            INTO :EF158-NUM-PROPOSTA
            FROM SEGUROS.EF_MATRICULA_INDICADOR
            WHERE NUM_CONTRATO_TERC = :EF158-NUM-CONTRATO-TERC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA
											FROM SEGUROS.EF_MATRICULA_INDICADOR
											WHERE NUM_CONTRATO_TERC = '{this.EF158_NUM_CONTRATO_TERC}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string EF158_NUM_PROPOSTA { get; set; }
        public string EF158_NUM_CONTRATO_TERC { get; set; }

        public static R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1 Execute(R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1 r20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF158_NUM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}