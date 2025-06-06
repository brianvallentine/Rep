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
    public class R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_EMAIL
            INTO :SEQ-EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            AND EMAIL = :EMAIL
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											AND EMAIL = '{this.EMAIL}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string SEQ_EMAIL { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }
        public string EMAIL { get; set; }

        public static R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1 Execute(R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1 r8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEQ_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}