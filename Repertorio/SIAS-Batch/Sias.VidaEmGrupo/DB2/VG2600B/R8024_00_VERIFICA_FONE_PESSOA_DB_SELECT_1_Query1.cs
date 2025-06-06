using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_FONE
            INTO :SEQ-FONE
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            AND DDD = :DDD
            AND NUM_FONE = :NUM-FONE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_FONE
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											AND DDD = '{this.DDD}'
											AND NUM_FONE = '{this.NUM_FONE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string SEQ_FONE { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }
        public string NUM_FONE { get; set; }
        public string DDD { get; set; }

        public static R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1 Execute(R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1 r8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEQ_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}