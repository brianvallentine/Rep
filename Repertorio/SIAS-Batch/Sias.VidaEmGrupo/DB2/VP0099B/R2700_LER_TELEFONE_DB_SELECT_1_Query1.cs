using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2700_LER_TELEFONE_DB_SELECT_1_Query1 : QueryBasis<R2700_LER_TELEFONE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DDI,
            DDD,
            NUM_FONE
            INTO :WS-DDI,
            :WS-DDD,
            :WS-NUM-FONE
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA = :WS-COD-PESSOA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DDI
							,
											DDD
							,
											NUM_FONE
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA = '{this.WS_COD_PESSOA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WS_DDI { get; set; }
        public string WS_DDD { get; set; }
        public string WS_NUM_FONE { get; set; }
        public string WS_COD_PESSOA { get; set; }

        public static R2700_LER_TELEFONE_DB_SELECT_1_Query1 Execute(R2700_LER_TELEFONE_DB_SELECT_1_Query1 r2700_LER_TELEFONE_DB_SELECT_1_Query1)
        {
            var ths = r2700_LER_TELEFONE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_LER_TELEFONE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_LER_TELEFONE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DDI = result[i++].Value?.ToString();
            dta.WS_DDD = result[i++].Value?.ToString();
            dta.WS_NUM_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}