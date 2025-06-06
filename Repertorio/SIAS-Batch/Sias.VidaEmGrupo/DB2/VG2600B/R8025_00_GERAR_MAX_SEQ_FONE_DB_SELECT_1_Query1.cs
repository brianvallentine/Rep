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
    public class R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1 : QueryBasis<R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_FONE), 0) + 1
            INTO :SEQ-FONE
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_FONE)
							, 0) + 1
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string SEQ_FONE { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }

        public static R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1 Execute(R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1 r8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1)
        {
            var ths = r8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEQ_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}