using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2247_CALCULO_IDADE_DB_SELECT_1_Query1 : QueryBasis<R2247_CALCULO_IDADE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO
            INTO :WS-DATA-NASCIMENTO
            FROM SEGUROS.PESSOA_FISICA
            WHERE COD_PESSOA =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
											FROM SEGUROS.PESSOA_FISICA
											WHERE COD_PESSOA =
											'{this.PROPOFID_COD_PESSOA}'";

            return query;
        }
        public string WS_DATA_NASCIMENTO { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static R2247_CALCULO_IDADE_DB_SELECT_1_Query1 Execute(R2247_CALCULO_IDADE_DB_SELECT_1_Query1 r2247_CALCULO_IDADE_DB_SELECT_1_Query1)
        {
            var ths = r2247_CALCULO_IDADE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2247_CALCULO_IDADE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2247_CALCULO_IDADE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_NASCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}